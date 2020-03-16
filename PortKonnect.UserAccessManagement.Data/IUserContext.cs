using System.Data.Entity;
using System.Linq;
using PortKonnect.UserAccessManagement.Domain;
using System.Data;

namespace PortKonnect.UserAccessManagement.Data
{
    public interface  IUserContext
    {
        IDbSet<Partner> Partners { get; set; }
        IDbSet<PartnerPort> PartnerPortOfOperations { get; set; }
        IDbSet<Subscription> Subscriptions { get; set; }
        IDbSet<SubscriptionMember> SubscriptionMembers { get; set; }
        IDbSet<Application> Applications { get; set; }
        IDbSet<ApplicationEntity> ApplicationEntities { get; set; }
        IDbSet<ApplicationEntityFunction> ApplicationEntityFunctions { get; set; }
        IDbSet<Role> Roles { get; set; }
        IDbSet<RoleFunction> RoleFunctions { get; set; }
        IDbSet<User> Users { get; set; }
        IDbSet<UserPort> UserPorts { get; set; }
        IDbSet<UserRole> UserRoles { get; set; }
        IDbSet<UserMenuFunction> UserMenuFunctions { get; set; }
        IDbSet<ModulesEntityFunction> ModulesEntityFunctions { get; set; }
        IDbSet<UserRoleEntityFunction> UserRoleEntityFunctions { get; set; }
        IDbSet<PartnerTypeRole> PartnerTypeRoles { get; set; }
        IDbSet<ChangePasswordLog> ChangePasswordLogs { get; set; }
        IDbSet<PartnerTypes> PartnerTypes { get; set; }
        IDbSet<PartnerTypePriority> partnerTypePrioritys { get; set; }
		IDbSet<Conversation> Conversations { get; set; }
        IDbSet<PartnerRegistration> PartnerRegistrations { get; set; }
        IDbSet<PartnerDirectorDetails> PartnerDirectorDetails { get; set; }
        IDbSet<PartnerRegistrationDocs> PartnerRegistrationDocs { get; set; }
        IDbSet<SuperCategory> SuperCategories { get; set; }
        IDbSet<SubCategory> SubCategories { get; set; }
        IDbSet<Employee> Employees { get; set; }        

        int SaveChanges();
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified);
        bool Commit();
        void Rollback();
        void Dispose(bool disposing);
        void Dispose();
    }
}
