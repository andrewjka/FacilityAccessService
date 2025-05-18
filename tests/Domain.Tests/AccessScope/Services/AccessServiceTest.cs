using System;
using Business.AccessScope.Services;
using Domain.AccessScope.Actions;
using Domain.AccessScope.Models;
using Domain.AccessScope.Services;
using Domain.AccessScope.ValueObjects;
using Domain.CommonScope.PersistenceContext;
using Domain.CommonScope.Specification;
using Domain.CommonScope.ValueObjects;
using Domain.TerminalScope.Models;
using Event;
using FluentValidation;
using MessagingContract;
using Moq;

namespace Domain.Tests.AccessScope.Services;

// public class AccessServiceTest
// {
//     private readonly Guid _facilityId;
//     private readonly Mock<IPersistenceContextFactory> _persistenceFactoryMock;
//     private readonly Mock<IPublisher> _publisherMock;
//
//     private readonly IAccessService _service;
//
//     private readonly Terminal _terminal;
//     private readonly Token512Bit _token512Bit;
//
//     private readonly UserFacility _userFacility;
//     private readonly string _userId;
//
//     private readonly VerifyAccessModel _verifyAccessModel;
//     private readonly Mock<IValidator<VerifyAccessModel>> _verifyAccessVlMock;
//
//
//     public AccessServiceTest()
//     {
//         _verifyAccessVlMock = new Mock<IValidator<VerifyAccessModel>>();
//         _persistenceFactoryMock = new Mock<IPersistenceContextFactory>();
//         _publisherMock = new Mock<IPublisher>();
//
//         _service = new AccessService(
//             _verifyAccessVlMock.Object,
//             _persistenceFactoryMock.Object,
//             _publisherMock.Object
//         );
//
//
//         _facilityId = Guid.NewGuid();
//         _userId = Guid.NewGuid().ToString();
//
//         _token512Bit = Token512Bit.GenerateToken();
//         _terminal = new Terminal("checkpoint", _token512Bit, DateOnly.FromDateTime(DateTime.Today));
//
//         _userFacility = new UserFacility(_userId, _facilityId, new AccessPeriod(
//             DateOnly.MinValue, DateOnly.MaxValue)
//         );
//
//         _verifyAccessModel = new VerifyAccessModel(_userId, _facilityId, null); // TODO: fix passToken
//     }
//
//     [Fact]
//     public async void VerifyAccessAsync_ShouldReturnFalse_WhenThePassNotFound()
//     {
//         var contextMock = CreatePersistenceContext(_terminal);
//
//         _persistenceFactoryMock.Setup(cfg => cfg.CreatePersistenceContextAsync()
//         ).ReturnsAsync(contextMock.Object);
//
//
//         // Act
//         var hasAccess = await _service.VerifyAccessAsync(_verifyAccessModel);
//
//         // Assert
//         Assert.False(hasAccess);
//     }
//
//     [Fact]
//     public async void VerifyAccessAsync_ShouldReturnFalse_WhenAccessPeriodIsExpired()
//     {
//         var userFacility = new UserFacility(
//             _userId,
//             _facilityId,
//             new AccessPeriod(DateOnly.MinValue, DateOnly.FromDateTime(DateTime.Today.AddDays(-1))
//             )
//         );
//
//         var contextMock = CreatePersistenceContext(_terminal, userFacility);
//
//         _persistenceFactoryMock.Setup(cfg => cfg.CreatePersistenceContextAsync()
//         ).ReturnsAsync(contextMock.Object);
//
//
//         // Act
//         var hasAccess = await _service.VerifyAccessAsync(_verifyAccessModel);
//
//         // Assert
//         Assert.False(hasAccess);
//     }
//
//     [Fact]
//     public async void VerifyAccessAsync_ShouldReturnTrue_AndPublishEvent_WhenAllConditionsAreOK()
//     {
//         var contextMock = CreatePersistenceContext(_terminal, _userFacility);
//
//         _persistenceFactoryMock.Setup(cfg => cfg.CreatePersistenceContextAsync()
//         ).ReturnsAsync(contextMock.Object);
//
//
//         // Act
//         var hasAccess = await _service.VerifyAccessAsync(_verifyAccessModel);
//
//         // Assert
//         Assert.True(hasAccess);
//
//         _publisherMock.Verify(cfg => cfg.PublishAsync(It.IsAny<IEvent>()), Times.Once);
//     }
//
//
//     private Mock<IPersistenceContext> CreatePersistenceContext(
//         Terminal terminal = null,
//         UserFacility userFacility = null
//     )
//     {
//         var contextMock = new Mock<IPersistenceContext>();
//
//         contextMock.Setup(cfg => cfg.TerminalRepository.FirstByAsync(It.IsAny<Specification<Terminal>>())
//         ).ReturnsAsync(terminal);
//
//         contextMock.Setup(cfg => cfg.UserFacilityRepository.FirstByAsync(It.IsAny<Specification<UserFacility>>())
//         ).ReturnsAsync(userFacility);
//
//         return contextMock;
//     }
// }