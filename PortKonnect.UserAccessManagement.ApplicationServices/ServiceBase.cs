using System;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.Security.Authentication;
using System.ServiceModel;
using System.Web;
using log4net;
using log4net.Config;
using PortKonnect.Common.Domain.Model;
using PortKonnect.Common.Exceptions;
using PortKonnect.Common.Services;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.Domain.DTOS;
using MassTransit;
using System.Threading.Tasks;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Web.Script.Serialization;
using PortKonnect.UserAccessManagement.GlobalConstants;
using PortKonnect.Common.Contracts;

namespace PortKonnect.UserAccessManagement.ApplicationServices
{
    public class ServiceBase
    {
        public readonly ILog _log;
        protected IUserContext UserContext;
        public ContextDTO ApplicationContextDTO;
        public ServiceBase()
        {
            XmlConfigurator.Configure();
            _log = LogManager.GetLogger(typeof(ServiceBase));
        }
        protected T ExecuteFaultHandledOperation<T>(Func<T> codetoExecute)
        {
            try
            {
                var wfstopwatch = Stopwatch.StartNew();
                T response = default(T);
                if (codetoExecute != null)
                {
                    ApplicationContextDTO = GetTokenFromRequest();
                    response = codetoExecute.Invoke();
                }

                wfstopwatch.Stop();

                if (codetoExecute != null)
                {
                    string method = codetoExecute.Target + " " + codetoExecute.Method;
                    _log.Debug("Time Taken for " + method + " : " + wfstopwatch.ElapsedMilliseconds.ToString(CultureInfo.InvariantCulture));
                }

                return response;
            }
            catch (BusinessExceptions ex)
            {
                _log.Error("BusinessExceptions = ", ex);
                throw new BusinessExceptions(ex.Message);
            }
            catch (Exception ex)
            {
                _log.Error("Exception = ", ex);
                throw new FaultException(BusinessExceptions.InternalServerErrorMessage);
            }
            finally
            {
                if (UserContext != null)
                {
                    UserContext.Dispose();
                }
            }
        }
        protected void ExecuteFaultHandledOperation(Action codetoExecute)
        {
            try
            {
                var wfstopwatch = Stopwatch.StartNew();
                if (codetoExecute != null)
                {
                    ApplicationContextDTO = GetTokenFromRequest();
                    codetoExecute.Invoke();
                }

                wfstopwatch.Stop();
                if (codetoExecute != null)
                {
                    string method = codetoExecute.Target + " " + codetoExecute.Method;
                    _log.Debug("Time Taken for " + method + " : " + wfstopwatch.ElapsedMilliseconds.ToString(CultureInfo.InvariantCulture));
                }
            }
            catch (BusinessExceptions ex)
            {
                _log.Error("Business Validation : ", ex);
                throw new BusinessExceptions(ex.Message);
            }
            catch (Exception ex)
            {
                _log.Error("Exception = ", ex);
                throw new FaultException(BusinessExceptions.InternalServerErrorMessage);
            }
            finally
            {
                if (UserContext != null)
                {
                    UserContext.Dispose();
                }
            }
        }
        protected T EncloseTransactionAndHandleException<T>(Func<T> codeToExecute)
        {
            try
            {
                var wfstopwatch = Stopwatch.StartNew();
                ApplicationContextDTO = GetTokenFromRequest();

                UserContext.BeginTransaction();
                T response = default(T);
                if (codeToExecute != null)
                {
                    response = codeToExecute.Invoke();
                }
                UserContext.SaveChanges();
                UserContext.Commit();

                wfstopwatch.Stop();
                if (codeToExecute != null)
                {
                    string method = codeToExecute.Target + " " + codeToExecute.Method;
                }

                return response;
            }
            catch (BusinessExceptions ex)
            {
                UserContext.Rollback();
                _log.Error("BusinessExceptions = ", ex);
                throw new BusinessExceptions(ex.Message);
            }
            catch (Exception ex)
            {
                UserContext.Rollback();
                _log.Error("Exception = ", ex);
                throw new FaultException(BusinessExceptions.InternalServerErrorMessage);
            }
            finally
            {
                if (UserContext != null)
                {
                    UserContext.Dispose();
                }
            }
        }
        protected void EncloseTransactionAndHandleException(Action codeToExecute)
        {
            try
            {
                var wfstopwatch = Stopwatch.StartNew();

                UserContext.BeginTransaction();
                if (codeToExecute != null)
                {
                    ApplicationContextDTO = GetTokenFromRequest();
                    codeToExecute.Invoke();
                }
                UserContext.SaveChanges();
                UserContext.Commit();
                wfstopwatch.Stop();
                if (codeToExecute != null)
                {
                    string method = codeToExecute.Target + " " + codeToExecute.Method;
                    _log.Debug("Time Taken for " + method + " : " + wfstopwatch.ElapsedMilliseconds.ToString(CultureInfo.InvariantCulture));
                }
            }
            catch (BusinessExceptions ex)
            {
                UserContext.Rollback();
                _log.Error("Business Validation = ", ex);
                throw new BusinessExceptions(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                UserContext.Rollback();
                // _log.Error("Exception = ", ex);
                throw new FaultException(ex.Message);
            }
            catch (Exception ex)
            {
                UserContext.Rollback();
                _log.Error("Exception = ", ex);
                throw new FaultException(BusinessExceptions.InternalServerErrorMessage);
            }
            finally
            {
                if (UserContext != null)
                {
                    UserContext.Dispose();
                }
            }
        }
        protected T ExecuteFaultHandledOperationWithoutToken<T>(Func<T> codetoExecute)
        {
            try
            {
                var wfstopwatch = Stopwatch.StartNew();
                T response = default(T);
                if (codetoExecute != null)
                {
                    response = codetoExecute.Invoke();
                }

                wfstopwatch.Stop();

                if (codetoExecute != null)
                {
                    string method = codetoExecute.Target + " " + codetoExecute.Method;
                    _log.Debug("Time Taken for " + method + " : " + wfstopwatch.ElapsedMilliseconds.ToString(CultureInfo.InvariantCulture));
                }

                return response;
            }
            catch (BusinessExceptions ex)
            {
                _log.Error("BusinessExceptions = ", ex);
                throw new BusinessExceptions(ex.Message);
            }
            catch (Exception ex)
            {
                _log.Error("Exception = ", ex);
                throw new FaultException(BusinessExceptions.InternalServerErrorMessage);
            }
            finally
            {
                if (UserContext != null)
                {
                    UserContext.Dispose();
                }
            }
        }
        protected void EncloseTransactionAndHandleExceptionWithoutToken(Action codeToExecute)
        {
            try
            {
                var wfstopwatch = Stopwatch.StartNew();

                UserContext.BeginTransaction();
                if (codeToExecute != null)
                {
                    //ApplicationContextDTO = GetTokenFromRequest();
                    codeToExecute.Invoke();
                }
                UserContext.SaveChanges();
                UserContext.Commit();
                wfstopwatch.Stop();
                if (codeToExecute != null)
                {
                    string method = codeToExecute.Target + " " + codeToExecute.Method;
                    _log.Debug("Time Taken for " + method + " : " + wfstopwatch.ElapsedMilliseconds.ToString(CultureInfo.InvariantCulture));
                }
            }
            catch (BusinessExceptions ex)
            {
                UserContext.Rollback();
                _log.Error("Business Validation = ", ex);
                throw new BusinessExceptions(ex.Message);
            }
            catch (Exception ex)
            {
                UserContext.Rollback();
                _log.Error("Exception = ", ex);
                throw new FaultException(BusinessExceptions.InternalServerErrorMessage);
            }
            finally
            {
                if (UserContext != null)
                {
                    UserContext.Dispose();
                }
            }
        }

        private ContextDTO GetTokenFromRequest()
        {
            JavaScriptSerializerAdapter javaScriptSerializerAdapter = new JavaScriptSerializerAdapter();

            ContextDTO _userContextDto = new ContextDTO();
            try
            {
                if (!string.IsNullOrEmpty(HttpContext.Current.Request.Headers["Authorization"]))
                    _userContextDto.Token = HttpContext.Current.Request.Headers["Authorization"].Substring(7);

                //if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["symmetricKeyAsBase64"]))
                //{
                var handler = new JwtSecurityTokenHandler();
                var jsonobjContextDto = handler.ReadToken(_userContextDto.Token) as JwtSecurityToken;

                if (jsonobjContextDto == null)
                {
                    throw new AuthenticationException(BusinessExceptions.EmptyToken);
                }

                _userContextDto.UserName = jsonobjContextDto.Claims.Where(c => c.Type == "UserName")
                    .Select(c => c.Value).SingleOrDefault();
                //TODO:B: Handle the case if Application Id returned is not integer..
                _userContextDto.ApplicationId = Convert.ToInt32(jsonobjContextDto.Claims.Where(c => c.Type == "ApplicationId")
                    .Select(c => c.Value).SingleOrDefault());
                _userContextDto.SubscriberId = jsonobjContextDto.Claims.Where(c => c.Type == "SubscriberId")
                    .Select(c => c.Value).SingleOrDefault();
                _userContextDto.PortCode = jsonobjContextDto.Claims.Where(c => c.Type == "PortCode")
                    .Select(c => c.Value).SingleOrDefault();
                _userContextDto.MemberId = jsonobjContextDto.Claims.Where(c => c.Type == "MemberId")
                    .Select(c => c.Value).SingleOrDefault();
                _userContextDto.MemberCode = jsonobjContextDto.Claims.Where(c => c.Type == "MemberCode")
                    .Select(c => c.Value).SingleOrDefault();
                _userContextDto.MemberType = jsonobjContextDto.Claims.Where(c => c.Type == "MemberType")
                    .Select(c => c.Value).SingleOrDefault();
                _userContextDto.UserId = jsonobjContextDto.Claims.Where(c => c.Type == "UserId")
                    .Select(c => c.Value).SingleOrDefault();
                _userContextDto.IsFirstTimeLogin =
                    jsonobjContextDto.Claims.Where(c => c.Type == "IsFirstTimeLogin").Select(c => c.Value).SingleOrDefault();
                _userContextDto.PartnerTypes =
                    jsonobjContextDto.Claims.Where(c => c.Type == "PartnerTypes").Select(c => c.Value).SingleOrDefault();
                _userContextDto.UserRoles = string.Join(",",
                    jsonobjContextDto.Claims.Where(c => c.Type == "UserRoles").Select(c => c.Value).ToList());
                //  }
            }
            catch (Exception ex)
            {
                log_error("User defined unhandled Exception : UAM Application Service Base : GetFromCookie() ", ex);
            }

            return _userContextDto;
        }
        private void log_error(string pretext, Exception ex)
        {
            string msg = "User Access Management - ApplicationService - ServiceBase - ERROR : " + pretext + " " + ex.Message;
            if (ex.InnerException != null)
            {
                if (!string.IsNullOrEmpty(ex.InnerException.Message))
                {
                    msg = msg + " Inner Exception:" + ex.InnerException.Message;
                }
            }
            _log.Error(msg);

        }

        public void SendAddOrUpdateUserNotification(UserDTO userDto)
        {
            Uri rabbitMqRootUri = new Uri(ConfigurationManager.AppSettings["RabbitMQHost"]);

            IBusControl rabbitBusControl = Bus.Factory.CreateUsingRabbitMq(rabbit =>
            {
                rabbit.Host(rabbitMqRootUri, settings =>
                {
                    settings.Username(ConfigurationManager.AppSettings["RabbitMqUserName"]);
                    settings.Password(ConfigurationManager.AppSettings["RabbitMqPassword"]);
                });
            });

            var user = new
            {
                UserDTO = userDto
            };
            user.UserDTO.LoginLink = ConfigurationManager.AppSettings["TokenServiceURL"];
            Task publishTask = rabbitBusControl.Publish<IUserEvent>(user);
        }
        public void SendAddEmployeeNotification(int appId, string subscriberId, string employeeId, EmployeeDTO employee)
        {
            Uri rabbitMqRootUri = new Uri(ConfigurationManager.AppSettings["RabbitMQHost"]);

            IBusControl rabbitBusControl = Bus.Factory.CreateUsingRabbitMq(rabbit =>
            {
                rabbit.Host(rabbitMqRootUri, settings =>
                {
                    settings.Username(ConfigurationManager.AppSettings["RabbitMqUserName"]);
                    settings.Password(ConfigurationManager.AppSettings["RabbitMqPassword"]);
                });
            });

            Task publishTask = rabbitBusControl.Publish<IEmployeeAddEvent>(new
            {
                AppId = appId,
                SubscriberId = subscriberId,
                EmployeeId = employeeId,
                Employee = employee
            });

        }

        public void SendAddRoleNotification(RoleDTO role)
        {
            Uri rabbitMqRootUri = new Uri(ConfigurationManager.AppSettings["RabbitMQHost"]);

            IBusControl rabbitBusControl = Bus.Factory.CreateUsingRabbitMq(rabbit =>
            {
                rabbit.Host(rabbitMqRootUri, settings =>
                {
                    settings.Username(ConfigurationManager.AppSettings["RabbitMqUserName"]);
                    settings.Password(ConfigurationManager.AppSettings["RabbitMqPassword"]);
                });
            });

            Task publishTask = rabbitBusControl.Publish<IRoleAddEvent>(new
            {
                Role = role
            });
        }
        

        public void SendNotification(int appId, string subscriberId, string memeberId, string appEntityId, string entityFunctionCode, string referenceId, string attachments, string userId, Object T)
        {
            NotificationTracker notificationTracker = new NotificationTracker()
            {
                ApplicationId = appId,
                SubscriberId = subscriberId,
                MemeberId = memeberId,
                ApplicationEntityId = appEntityId,
                FunctionCode = entityFunctionCode,
                ReferenceId = referenceId,
                Attachments = attachments,
                UserId = userId,
                NotificationObj = T
            };

            var jsonObj = new JavaScriptSerializer().Serialize(notificationTracker);

            PushMessageToNotificationQueue(notificationTracker);//, UAMGlobalConstants.GeneralNotificationQueue);
            _log.Info("Notification pushed to Queue with data : " + jsonObj);

        }

        public void PushMessageToNotificationQueue(NotificationTracker notificationTracker)//, string queueName)
        {
            Uri rabbitMqRootUri = new Uri(ConfigurationManager.AppSettings["RabbitMQHost"]);

            IBusControl bus = Bus.Factory.CreateUsingRabbitMq(rabbit =>
            {
                rabbit.Host(rabbitMqRootUri, settings =>
                {
                    settings.Username(ConfigurationManager.AppSettings["RabbitMqUserName"]);
                    settings.Password(ConfigurationManager.AppSettings["RabbitMqPassword"]);
                });
            });
            var jsonObj = new JavaScriptSerializer().Serialize(notificationTracker);

            try
            {
                NotificationTracker notificationTrackerJson = new JavaScriptSerializer().Deserialize<NotificationTracker>(jsonObj);
                Task publishTask = bus.Publish<INotificationTracker>(notificationTracker);
                _log.Info(string.Format("Notification is pushed to queue successfully  with status {0} and Json Data {1} :", publishTask.Status, jsonObj));
            }
            catch (Exception ex)
            {
               _log.Error("Notification push to Queue with data : " + jsonObj +"; Failed with following exception " + ex);
            }
            finally
            {
                bus.Stop();
            }

        }
    }
}
