using System;
using FacilityAccessService.Business.AccessScope.Actions;
using FacilityAccessService.Business.AccessScope.Models;
using FacilityAccessService.Business.AccessScope.Services;
using FacilityAccessService.Business.AccessScope.ValueObjects;
using FacilityAccessService.Business.CommonScope.PersistenceContext;
using FacilityAccessService.Business.CommonScope.Specification;
using FacilityAccessService.Business.TerminalScope.Exceptions;
using FacilityAccessService.Business.TerminalScope.Models;
using FacilityAccessService.Business.TerminalScope.ValueObjects;
using FacilityAccessService.Domain.AccessScope.Services;
using FacilityAccessService.Event;
using FluentValidation;
using Moq;

namespace Domain.Tests.AccessScope.Services
{
    public class AccessControlTerminalServiceTest
    {
        private readonly Mock<IValidator<VerifyAccessViaTerminalModel>> _verifyAccessViaTerminalVlMock;
        private readonly Mock<IPersistenceContextFactory> _persistenceFactoryMock;
        private readonly Mock<IPublisher> _publisherMock;

        private readonly IAccessControlTerminalService _service;
        
        
        private readonly Guid _facilityId;
        private readonly string _userId;

        private readonly Terminal _terminal;
        private readonly TerminalToken _terminalToken;

        private readonly UserFacility _userFacility;

        private readonly VerifyAccessViaTerminalModel _verifyAccessModel;


        public AccessControlTerminalServiceTest()
        {
            _verifyAccessViaTerminalVlMock = new Mock<IValidator<VerifyAccessViaTerminalModel>>();
            _persistenceFactoryMock = new Mock<IPersistenceContextFactory>();
            _publisherMock = new Mock<IPublisher>();

            _service = new AccessControlTerminalService(
                verifyAccessViaTerminalVl: _verifyAccessViaTerminalVlMock.Object,
                persistenceContextFactory: _persistenceFactoryMock.Object,
                publisher: _publisherMock.Object
            );


            this._facilityId = Guid.NewGuid();
            this._userId = Guid.NewGuid().ToString();

            this._terminalToken = TerminalToken.GenerateToken();
            this._terminal = new Terminal("checkpoint", this._terminalToken, DateOnly.FromDateTime(DateTime.Today));

            this._userFacility = new UserFacility(this._userId, this._facilityId, new AccessPeriod(
                DateOnly.MinValue, DateOnly.MaxValue)
            );

            this._verifyAccessModel = new VerifyAccessViaTerminalModel(_terminalToken, _userId, _facilityId);
        }

        [Fact]
        public async void VerifyAccessAsync_ShouldThrowTerminalTokenInvalidException_WhenTerminalNotFound()
        {
            var contextMock = CreatePersistenceContext(null, this._userFacility);

            _persistenceFactoryMock.Setup(
                cfg => cfg.CreatePersistenceContext()
            ).ReturnsAsync(contextMock.Object);


            // Act + Assert
            await Assert.ThrowsAsync<TerminalTokenInvalidException>(async () =>
                await _service.VerifyAccessAsync(this._verifyAccessModel)
            );
        }

        [Fact]
        public async void VerifyAccessAsync_ShouldThrowTerminalTokenInvalidException_WhenThePassNotFound()
        {
            var contextMock = CreatePersistenceContext(this._terminal, null);

            _persistenceFactoryMock.Setup(
                cfg => cfg.CreatePersistenceContext()
            ).ReturnsAsync(contextMock.Object);


            // Act
            bool hasAccess = await _service.VerifyAccessAsync(this._verifyAccessModel);

            // Assert
            Assert.False(hasAccess);
        }

        [Fact]
        public async void VerifyAccessAsync_ShouldThrowTerminalTokenInvalidException_WhenTerminalTokenExpired()
        {
            var terminal = new Terminal(
                name: "checkpoint1",
                token: this._terminalToken,
                expiredTokenOn: DateOnly.FromDateTime(DateTime.Today.AddDays(-1))
            );

            var contextMock = CreatePersistenceContext(terminal, this._userFacility);

            _persistenceFactoryMock.Setup(
                cfg => cfg.CreatePersistenceContext()
            ).ReturnsAsync(contextMock.Object);


            // Act + Assert
            await Assert.ThrowsAsync<TerminalTokenInvalidException>(async () =>
                await _service.VerifyAccessAsync(this._verifyAccessModel)
            );
        }

        [Fact]
        public async void VerifyAccessAsync_ShouldReturnFalse_WhenAccessPeriodIsExpired()
        {
            var userFacility = new UserFacility(
                userId: this._userId,
                facilityId: this._facilityId,
                accessPeriod: new AccessPeriod(DateOnly.MinValue, DateOnly.FromDateTime(DateTime.Today.AddDays(-1))
                )
            );

            var contextMock = CreatePersistenceContext(this._terminal, userFacility);

            _persistenceFactoryMock.Setup(
                cfg => cfg.CreatePersistenceContext()
            ).ReturnsAsync(contextMock.Object);


            // Act
            bool hasAccess = await _service.VerifyAccessAsync(this._verifyAccessModel);

            // Assert
            Assert.False(hasAccess);
        }

        [Fact]
        public async void VerifyAccessAsync_ShouldReturnTrue_AndPublishEvent_WhenAllConditionsAreOK()
        {
            var contextMock = CreatePersistenceContext(this._terminal, this._userFacility);

            _persistenceFactoryMock.Setup(
                cfg => cfg.CreatePersistenceContext()
            ).ReturnsAsync(contextMock.Object);


            // Act
            bool hasAccess = await _service.VerifyAccessAsync(this._verifyAccessModel);

            // Assert
            Assert.True(hasAccess);

            _publisherMock.Verify(cfg => cfg.PublishAsync(It.IsAny<object>()), Times.Once);
        }


        private Mock<IPersistenceContext> CreatePersistenceContext(
            Terminal terminal = null,
            UserFacility userFacility = null
        )
        {
            var contextMock = new Mock<IPersistenceContext>();

            contextMock.Setup(
                cfg => cfg.TerminalRepository.FirstByAsync(It.IsAny<Specification<Terminal>>())
            ).ReturnsAsync(terminal);

            contextMock.Setup(
                cfg => cfg.UserFacilityRepository.FirstByAsync(It.IsAny<Specification<UserFacility>>())
            ).ReturnsAsync(userFacility);

            return contextMock;
        }
    }
}