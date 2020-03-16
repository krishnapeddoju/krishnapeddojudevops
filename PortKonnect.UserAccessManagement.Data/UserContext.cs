using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using PortKonnect.UserAccessManagement.Data.Mapping;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.Data.Mapping;
using PortKonnect.UserManagement.Data.Mapping;

namespace PortKonnect.UserAccessManagement.Data
{
    public class UserContext : DbContext, IUserContext
    {
        private readonly string _defaultSchema;

        private bool _disposed;
        private ObjectContext _objectContext;
        private Dictionary<string, object> _repositories;
        private DbTransaction _transaction;

        static UserContext()
        {
            Database.SetInitializer<UserContext>(null);
        }

        public UserContext()
            : base("Name=UserContext")
        {
            Database.SetInitializer<UserContext>(null);
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
            Configuration.AutoDetectChangesEnabled = true;
            _defaultSchema = "USAM";
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
        public IDbSet<Partner> Partners { get; set; }
        public IDbSet<PartnerPort> PartnerPortOfOperations { get; set; }
        public IDbSet<Subscription> Subscriptions { get; set; }
        public IDbSet<SubscriptionMember> SubscriptionMembers { get; set; }
        public IDbSet<Application> Applications { get; set; }
        //public IDbSet<ApplicationModule> ApplicationModules { get; set; }
        //public IDbSet<ApplicationModuleEntity> ApplicationModuleEntities { get; set; }
        public IDbSet<ApplicationEntity> ApplicationEntities { get; set; }
        public IDbSet<ApplicationEntityFunction> ApplicationEntityFunctions { get; set; }
        public IDbSet<Role> Roles { get; set; }
        public IDbSet<RoleFunction> RoleFunctions { get; set; }
        public IDbSet<User> Users { get; set; }
        public IDbSet<UserPort> UserPorts { get; set; }
        public IDbSet<UserRole> UserRoles { get; set; }
        public IDbSet<UserMenuFunction> UserMenuFunctions { get; set; }
        public IDbSet<ModulesEntityFunction> ModulesEntityFunctions { get; set; }
        public IDbSet<UserRoleEntityFunction> UserRoleEntityFunctions { get; set; }
        public IDbSet<PartnerTypeRole> PartnerTypeRoles { get; set; }
        public IDbSet<ChangePasswordLog> ChangePasswordLogs { get; set; }
        public IDbSet<PartnerTypes> PartnerTypes { get; set; }
        public IDbSet<PartnerTypePriority> partnerTypePrioritys { get; set; }
		public IDbSet<Conversation> Conversations { get; set; }

        public IDbSet<PartnerRegistration> PartnerRegistrations { get; set; }
        public IDbSet<PartnerDirectorDetails> PartnerDirectorDetails { get; set; }
        public IDbSet<PartnerRegistrationDocs> PartnerRegistrationDocs { get; set; }
        public IDbSet<SuperCategory> SuperCategories { get; set; }      
        public IDbSet<SubCategory> SubCategories { get; set; }
        public IDbSet<Employee> Employees { get; set; }

        public bool AutoDetectChangesEnabled
        {
            get { return Configuration.AutoDetectChangesEnabled; }

            set { Configuration.AutoDetectChangesEnabled = value; }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (modelBuilder != null)
            {
                modelBuilder.HasDefaultSchema(_defaultSchema);

                modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

                modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

                modelBuilder.Configurations.Add(new PartnerMap());
                modelBuilder.Configurations.Add(new PartnerPortMap());
                modelBuilder.Configurations.Add(new SubscriptionMap());
                modelBuilder.Configurations.Add(new SubscriptionMemberMap());
                modelBuilder.Configurations.Add(new ApplicationMap());
                //modelBuilder.Configurations.Add(new ApplicationModuleMap());
                //modelBuilder.Configurations.Add(new ApplicationModuleEntityMap());
                modelBuilder.Configurations.Add(new ApplicationEntityMap());
                modelBuilder.Configurations.Add(new ApplicationEntityFunctionMap());
                modelBuilder.Configurations.Add(new RoleMap());
                modelBuilder.Configurations.Add(new RoleFunctionMap());
                modelBuilder.Configurations.Add(new UserMap());
                modelBuilder.Configurations.Add(new UserPortMap());
                modelBuilder.Configurations.Add(new UserRoleMap());
                modelBuilder.Configurations.Add(new UserMenuFunctionMap());
                modelBuilder.Configurations.Add(new UserRoleEntityFunctionMap());
                modelBuilder.Configurations.Add(new ModulesEntityFunctionMap());
                modelBuilder.Configurations.Add(new PartnerTypeRoleMap());
                modelBuilder.Configurations.Add(new ChangePasswordLogMap());
                modelBuilder.Configurations.Add(new PartnerTypesMap());
                modelBuilder.Configurations.Add(new PartnerTypePriorityMap());
				modelBuilder.Configurations.Add(new ConversationMap());

                modelBuilder.Configurations.Add(new PartnerRegistrationMap());
                modelBuilder.Configurations.Add(new PartnerRegistrationDocsMap());
                modelBuilder.Configurations.Add(new PartnerDirectorDetailsMap());

                modelBuilder.ComplexType<Address>();
                modelBuilder.ComplexType<UserPreference>();

                modelBuilder.Configurations.Add(new SuperCategoryMap());
                modelBuilder.Configurations.Add(new SubCategoryMap());
                modelBuilder.Configurations.Add(new EmployeeMap());

            }
        }

        public override int SaveChanges()
        {
            //List<DbEntityEntry> newOrChangedEntities = ChangeTracker.Entries().Where(e => e.State != EntityState.Unchanged || StateHelper.ConvertState(((IObjectState)e.Entity).ObjectState) != EntityState.Unchanged).ToList();

            List<DbEntityEntry> newOrChangedEntities = ChangeTracker.Entries().Where(e => e.State != EntityState.Unchanged).ToList();

            //foreach (DbEntityEntry newOrChangedEntity in newOrChangedEntities)
            //{
            //    AddTracking(newOrChangedEntity);
            //}

            return base.SaveChanges();
        }

        public void Dispose()
        {
            if (_objectContext != null)
            {
                if (_objectContext.Connection != null)
                {
                    if (_objectContext.Connection.State == ConnectionState.Open)
                    {
                        _objectContext.Connection.Close();
                    }
                }
            }

            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _objectContext = null;
                //  this.Dispose();
                //_dataContext.Dispose();
            }
            _disposed = true;
        }

        #region Transactions
        //IF 04/09/2014 Add IsolationLevel
        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified)
        {
            _objectContext = ((IObjectContextAdapter)this).ObjectContext;
            if (_objectContext.Connection.State != ConnectionState.Open)
            {
                _objectContext.Connection.Open();
            }

            _transaction = _objectContext.Connection.BeginTransaction();
        }

        public bool Commit()
        {
            _transaction.Commit();
            return true;
        }

        public void Rollback()
        {
            _transaction.Rollback();
            //this.SyncObjectsStatePostCommit();
            // ((DataContext)_dataContext).SyncObjectsStatePostCommit();
        }
        #endregion



        private void AddTracking(DbEntityEntry newOrChangedEntity)
        {
            //EntityBase entity = newOrChangedEntity.Entity as EntityBase;

            //if (entity == null)
            //    return;

            // TODO: get userID
            //int userId = 1;
            DateTime saveDate = DateTime.UtcNow;

            //switch (newOrChangedEntity.State)
            //{
            //    case EntityState.Added:
            //        entity.CreatedBy = userId;
            //        entity.CreatedOn = saveDate;
            //        entity.ModifiedBy = userId;
            //        entity.ModifiedOn = saveDate;
            //        break;
            //    case EntityState.Modified:
            //        entity.ModifiedBy = userId;
            //        entity.ModifiedOn = saveDate;
            //        break;
            //}
        }
    }
}
