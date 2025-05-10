using System;
using System.Threading.Tasks;
using AutoMapper;
using Domain.AccessScope.Repositories;
using Domain.CommonScope.PersistenceContext;
using Domain.FacilityScope.Repositories;
using Domain.TerminalScope.Repositories;
using Domain.UserScope.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using Persistence.AccessScope.Repositories;
using Persistence.FacilityScope.Repositories;
using Persistence.TerminalScope.Repositories;
using Persistence.UserScope.Repositories;

namespace Persistence.CommonScope.PersistenceContext;

public class PersistenceContext : IPersistenceContext
{
    private readonly IMapper _mapper;
    private ICategoryRepository _categoryRepository;
    private AppDatabaseContext _context;
    private IFacilityRepository _facilityRepository;

    private bool _isTransactionProcessed;
    private ITerminalRepository _terminalRepository;

    private IDbContextTransaction _transaction;
    private IUserCategoryRepository _userCategoryRepository;
    private IUserFacilityRepository _userFacilityRepository;
    private IUserRepository _userRepository;


    public PersistenceContext(
        AppDatabaseContext context,
        IDbContextTransaction transaction,
        IMapper mapper)
    {
        if (context is null) throw new ArgumentNullException(nameof(context));
        if (transaction is null) throw new ArgumentNullException(nameof(transaction));
        if (mapper is null) throw new ArgumentNullException(nameof(mapper));

        _context = context;
        _transaction = transaction;
        _mapper = mapper;
    }

    public IUserRepository UserRepository => _userRepository ??= new UserRepository(
        _context,
        _mapper
    );

    public ITerminalRepository TerminalRepository => _terminalRepository ??= new TerminalRepository(
        _context,
        _mapper
    );

    public IFacilityRepository FacilityRepository => _facilityRepository ??= new FacilityRepository(
        _context,
        _mapper
    );

    public ICategoryRepository CategoryRepository => _categoryRepository ??= new CategoryRepository(
        _context,
        _mapper
    );

    public IUserFacilityRepository UserFacilityRepository => _userFacilityRepository ??= new UserFacilityRepository(
        _context,
        _mapper
    );

    public IUserCategoryRepository UserCategoryRepository => _userCategoryRepository ??= new UserCategoryRepository(
        _context,
        _mapper
    );


    public async Task ApplyChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task CommitAsync()
    {
        if (_isTransactionProcessed) return;

        await _transaction.CommitAsync();
        _isTransactionProcessed = true;
    }

    public async Task RollBackAsync()
    {
        if (_isTransactionProcessed) return;

        await _transaction.RollbackAsync();
        _isTransactionProcessed = true;
    }


    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncCore();

        GC.SuppressFinalize(this);
    }

    protected virtual async ValueTask DisposeAsyncCore()
    {
        if (!_isTransactionProcessed) await RollBackAsync();

        if (_transaction is not null) await _transaction.DisposeAsync();

        _context = null;
        _transaction = null;
    }
}