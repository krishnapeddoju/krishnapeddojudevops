insert into USAM.APPLICATIONMODULE(MODULECODE, APPLICATIONID, MODULENAME, MENUORDER, RECORDSTATUS, CREATEDBY, MODULEURL)
values('PKMOBILE', 6, 'Mobile', 25, 'A', 'Admin', 'http://192.168.0.138:8100');
---------------------------------------

--Notifications
insert into USAM.APPLICATIONMODULEENTITY(MODULECODE, APPLICATIONENTITYID, MENUORDER, ISDELETED, RECORDSTATUS, CREATEDBY)
values ( 'PKMOBILE', 'MobNotifications', 25, 'N', 'A', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');

insert into usam.applicationentityfunction(APPLICATIONENTITYID, FUNCTIONCODE, FUNCTIONNAME, FORMURL,ISMENU, MENUORDER, ISDELETED, RECORDSTATUS, CREATEDBY )
 values ('MobNotifications', 'MobNotificationsList', 'Notifications', 'notifications', 'Y', 5, 'N', 'A', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');

INSERT INTO usam.RoleFunction
(ROLEID,APPLICATIONENTITYID,FUNCTIONCODE,ISDELETED,RECORDSTATUS,CREATEDBY,CREATEDON,APPLICATIONID,SUBSCRIBERID) values
('Admin','MobNotifications','MobNotificationsList','N','A','1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0',sysdate,6,'KPCL');

insert into USAM.APPLICATIONENTITY(APPLICATIONENTITYID, APPLICATIONID, ENTITYNAME, FORMURL, ISMENU, MAILNOTIFICATION, SYSNOTIFICATION,
 SMS, WORKFLOW, MENUORDER, ISDELETED, RECORDSTATUS,MENUICON,Menuicon2, CREATEDBY ) 
values ('MobNotifications', 6, 'Notifications', '', 'Y', 'N', 'N', 'N', 'N', 5, 'N','A','','', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');

--------------------------------------
--Planned Movements
insert into USAM.APPLICATIONMODULEENTITY(MODULECODE, APPLICATIONENTITYID, MENUORDER, ISDELETED, RECORDSTATUS, CREATEDBY)
values ( 'PKMOBILE', 'MobPlannedMovements', 25, 'N', 'A', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');

insert into usam.applicationentityfunction(APPLICATIONENTITYID, FUNCTIONCODE, FUNCTIONNAME, FORMURL,ISMENU, MENUORDER, ISDELETED, RECORDSTATUS, CREATEDBY )
 values ('MobPlannedMovements', 'MobPlannedMovementList', 'Planned Movements', 'planned-movements', 'Y', 10, 'N', 'A', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');

INSERT INTO usam.RoleFunction
(ROLEID,APPLICATIONENTITYID,FUNCTIONCODE,ISDELETED,RECORDSTATUS,CREATEDBY,CREATEDON,APPLICATIONID,SUBSCRIBERID) values
('Admin','MobPlannedMovements','MobPlannedMovementList','N','A','1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0',sysdate,6,'KPCL');

insert into USAM.APPLICATIONENTITY(APPLICATIONENTITYID, APPLICATIONID, ENTITYNAME, FORMURL, ISMENU, MAILNOTIFICATION, SYSNOTIFICATION,
 SMS, WORKFLOW, MENUORDER, ISDELETED, RECORDSTATUS,MENUICON,Menuicon2, CREATEDBY ) 
values ('MobPlannedMovements', 6, 'Planned Movements', '', 'Y', 'N', 'N', 'N', 'N', 10, 'N','A','','', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');
--------------------------------------
--Incident Reporting
insert into USAM.APPLICATIONMODULEENTITY(MODULECODE, APPLICATIONENTITYID, MENUORDER, ISDELETED, RECORDSTATUS, CREATEDBY)
values ( 'PKMOBILE', 'MobIncidentReporting', 25, 'N', 'A', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');

insert into usam.applicationentityfunction(APPLICATIONENTITYID, FUNCTIONCODE, FUNCTIONNAME, FORMURL,ISMENU, MENUORDER, ISDELETED, RECORDSTATUS, CREATEDBY )
 values ('MobIncidentReporting', 'MobIncidentReportingList', 'Incident Reporting', 'incident-reporting', 'Y', 15, 'N', 'A', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');

INSERT INTO usam.RoleFunction
(ROLEID,APPLICATIONENTITYID,FUNCTIONCODE,ISDELETED,RECORDSTATUS,CREATEDBY,CREATEDON,APPLICATIONID,SUBSCRIBERID) values
('Admin','MobIncidentReporting','MobIncidentReportingList','N','A','1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0',sysdate,6,'KPCL');

insert into USAM.APPLICATIONENTITY(APPLICATIONENTITYID, APPLICATIONID, ENTITYNAME, FORMURL, ISMENU, MAILNOTIFICATION, SYSNOTIFICATION,
 SMS, WORKFLOW, MENUORDER, ISDELETED, RECORDSTATUS,MENUICON,Menuicon2, CREATEDBY ) 
values ('MobIncidentReporting', 6, 'Incident Reporting', '', 'Y', 'N', 'N', 'N', 'N', 15, 'N','A','','', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');
--------------------------------------
--Scheduled Task
insert into USAM.APPLICATIONMODULEENTITY(MODULECODE, APPLICATIONENTITYID, MENUORDER, ISDELETED, RECORDSTATUS, CREATEDBY)
values ( 'PKMOBILE', 'MobScheduledTask', 25, 'N', 'A', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');

insert into usam.applicationentityfunction(APPLICATIONENTITYID, FUNCTIONCODE, FUNCTIONNAME, FORMURL,ISMENU, MENUORDER, ISDELETED, RECORDSTATUS, CREATEDBY )
 values ('MobScheduledTask', 'MobScheduledTaskList', 'Scheduled Task', 'scheduled-task', 'Y', 20, 'N', 'A', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');

INSERT INTO usam.RoleFunction
(ROLEID,APPLICATIONENTITYID,FUNCTIONCODE,ISDELETED,RECORDSTATUS,CREATEDBY,CREATEDON,APPLICATIONID,SUBSCRIBERID) values
('Admin','MobScheduledTask','MobScheduledTaskList','N','A','1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0',sysdate,6,'KPCL');

insert into USAM.APPLICATIONENTITY(APPLICATIONENTITYID, APPLICATIONID, ENTITYNAME, FORMURL, ISMENU, MAILNOTIFICATION, SYSNOTIFICATION,
 SMS, WORKFLOW, MENUORDER, ISDELETED, RECORDSTATUS,MENUICON,Menuicon2, CREATEDBY ) 
values ('MobScheduledTask', 6, 'Scheduled Task', '', 'Y', 'N', 'N', 'N', 'N', 20, 'N','A','','', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');
--------------------------------------
--Marine Service Request
insert into USAM.APPLICATIONMODULEENTITY(MODULECODE, APPLICATIONENTITYID, MENUORDER, ISDELETED, RECORDSTATUS, CREATEDBY)
values ( 'PKMOBILE', 'MobMarineServiceRequest', 25, 'N', 'A', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');

insert into usam.applicationentityfunction(APPLICATIONENTITYID, FUNCTIONCODE, FUNCTIONNAME, FORMURL,ISMENU, MENUORDER, ISDELETED, RECORDSTATUS, CREATEDBY )
 values ('MobMarineServiceRequest', 'MobMarineServiceRequestList', 'Marine Service Request', 'marine-service-request', 'Y', 25, 'N', 'A', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');

INSERT INTO usam.RoleFunction
(ROLEID,APPLICATIONENTITYID,FUNCTIONCODE,ISDELETED,RECORDSTATUS,CREATEDBY,CREATEDON,APPLICATIONID,SUBSCRIBERID) values
('Admin','MobMarineServiceRequest','MobMarineServiceRequestList','N','A','1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0',sysdate,6,'KPCL');

insert into USAM.APPLICATIONENTITY(APPLICATIONENTITYID, APPLICATIONID, ENTITYNAME, FORMURL, ISMENU, MAILNOTIFICATION, SYSNOTIFICATION,
 SMS, WORKFLOW, MENUORDER, ISDELETED, RECORDSTATUS,MENUICON,Menuicon2, CREATEDBY ) 
values ('MobMarineServiceRequest', 6, 'Marine Service Request', '', 'Y', 'N', 'N', 'N', 'N', 25, 'N','A','','', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');
--------------------------------------
--Change ETA/ETD
insert into USAM.APPLICATIONMODULEENTITY(MODULECODE, APPLICATIONENTITYID, MENUORDER, ISDELETED, RECORDSTATUS, CREATEDBY)
values ( 'PKMOBILE', 'MobChangeETAETD', 25, 'N', 'A', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');

insert into usam.applicationentityfunction(APPLICATIONENTITYID, FUNCTIONCODE, FUNCTIONNAME, FORMURL,ISMENU, MENUORDER, ISDELETED, RECORDSTATUS, CREATEDBY )
 values ('MobChangeETAETD', 'MobChangeETAETDList', 'Change ETA/ETD', 'change-eta-etd', 'Y', 30, 'N', 'A', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');

INSERT INTO usam.RoleFunction
(ROLEID,APPLICATIONENTITYID,FUNCTIONCODE,ISDELETED,RECORDSTATUS,CREATEDBY,CREATEDON,APPLICATIONID,SUBSCRIBERID) values
('Admin','MobChangeETAETD','MobChangeETAETDList','N','A','1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0',sysdate,6,'KPCL');

insert into USAM.APPLICATIONENTITY(APPLICATIONENTITYID, APPLICATIONID, ENTITYNAME, FORMURL, ISMENU, MAILNOTIFICATION, SYSNOTIFICATION,
 SMS, WORKFLOW, MENUORDER, ISDELETED, RECORDSTATUS,MENUICON,Menuicon2, CREATEDBY ) 
values ('MobChangeETAETD', 6, 'Change ETA/ETD', '', 'Y', 'N', 'N', 'N', 'N', 30, 'N','A','','', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');
--------------------------------------
--Tally Operation
insert into USAM.APPLICATIONMODULEENTITY(MODULECODE, APPLICATIONENTITYID, MENUORDER, ISDELETED, RECORDSTATUS, CREATEDBY)
values ( 'PKMOBILE', 'MobTallyOperation', 25, 'N', 'A', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');

insert into usam.applicationentityfunction(APPLICATIONENTITYID, FUNCTIONCODE, FUNCTIONNAME, FORMURL,ISMENU, MENUORDER, ISDELETED, RECORDSTATUS, CREATEDBY )
 values ('MobTallyOperation', 'MobTallyOperationList', 'Tally Operation', 'vessel-cargo-operation', 'Y', 35, 'N', 'A', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');

INSERT INTO usam.RoleFunction
(ROLEID,APPLICATIONENTITYID,FUNCTIONCODE,ISDELETED,RECORDSTATUS,CREATEDBY,CREATEDON,APPLICATIONID,SUBSCRIBERID) values
('Admin','MobTallyOperation','MobTallyOperationList','N','A','1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0',sysdate,6,'KPCL');

insert into USAM.APPLICATIONENTITY(APPLICATIONENTITYID, APPLICATIONID, ENTITYNAME, FORMURL, ISMENU, MAILNOTIFICATION, SYSNOTIFICATION,
 SMS, WORKFLOW, MENUORDER, ISDELETED, RECORDSTATUS,MENUICON,Menuicon2, CREATEDBY ) 
values ('MobTallyOperation', 6, 'Tally Operation', '', 'Y', 'N', 'N', 'N', 'N', 35, 'N','A','','', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');
--------------------------------------
--Draft Survey
insert into USAM.APPLICATIONMODULEENTITY(MODULECODE, APPLICATIONENTITYID, MENUORDER, ISDELETED, RECORDSTATUS, CREATEDBY)
values ( 'PKMOBILE', 'MobDraftSurvey', 25, 'N', 'A', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');

insert into usam.applicationentityfunction(APPLICATIONENTITYID, FUNCTIONCODE, FUNCTIONNAME, FORMURL,ISMENU, MENUORDER, ISDELETED, RECORDSTATUS, CREATEDBY )
 values ('MobDraftSurvey', 'MobDraftSurveyList', 'Draft Survey', 'draft-survey', 'Y', 40, 'N', 'A', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');

INSERT INTO usam.RoleFunction
(ROLEID,APPLICATIONENTITYID,FUNCTIONCODE,ISDELETED,RECORDSTATUS,CREATEDBY,CREATEDON,APPLICATIONID,SUBSCRIBERID) values
('Admin','MobDraftSurvey','MobDraftSurveyList','N','A','1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0',sysdate,6,'KPCL');

insert into USAM.APPLICATIONENTITY(APPLICATIONENTITYID, APPLICATIONID, ENTITYNAME, FORMURL, ISMENU, MAILNOTIFICATION, SYSNOTIFICATION,
 SMS, WORKFLOW, MENUORDER, ISDELETED, RECORDSTATUS,MENUICON,Menuicon2, CREATEDBY ) 
values ('MobDraftSurvey', 6, 'Draft Survey', '', 'Y', 'N', 'N', 'N', 'N', 40, 'N','A','','', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');
--------------------------------------
--Record Cargo Unloading From Jetty
insert into USAM.APPLICATIONMODULEENTITY(MODULECODE, APPLICATIONENTITYID, MENUORDER, ISDELETED, RECORDSTATUS, CREATEDBY)
values ( 'PKMOBILE', 'MobRecordCargoUnloadingFromJetty', 25, 'N', 'A', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');

insert into usam.applicationentityfunction(APPLICATIONENTITYID, FUNCTIONCODE, FUNCTIONNAME, FORMURL,ISMENU, MENUORDER, ISDELETED, RECORDSTATUS, CREATEDBY )
 values ('MobRecordCargoUnloadingFromJetty', 'MobRecordCargoUnloadingFromJettyList', 'Record Cargo Unloading From Jetty', 'record-cargo-unloading-from-jetty', 'Y', 45, 'N', 'A', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');

INSERT INTO usam.RoleFunction
(ROLEID,APPLICATIONENTITYID,FUNCTIONCODE,ISDELETED,RECORDSTATUS,CREATEDBY,CREATEDON,APPLICATIONID,SUBSCRIBERID) values
('Admin','MobRecordCargoUnloadingFromJetty','MobRecordCargoUnloadingFromJettyList','N','A','1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0',sysdate,6,'KPCL');

insert into USAM.APPLICATIONENTITY(APPLICATIONENTITYID, APPLICATIONID, ENTITYNAME, FORMURL, ISMENU, MAILNOTIFICATION, SYSNOTIFICATION,
 SMS, WORKFLOW, MENUORDER, ISDELETED, RECORDSTATUS,MENUICON,Menuicon2, CREATEDBY ) 
values ('MobRecordCargoUnloadingFromJetty', 6, 'Record Cargo Unloading From Jetty', '', 'Y', 'N', 'N', 'N', 'N', 45, 'N','A','','', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');
--------------------------------------
--Cargo Handling
insert into USAM.APPLICATIONMODULEENTITY(MODULECODE, APPLICATIONENTITYID, MENUORDER, ISDELETED, RECORDSTATUS, CREATEDBY)
values ( 'PKMOBILE', 'MobCargoHandling', 25, 'N', 'A', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');

insert into usam.applicationentityfunction(APPLICATIONENTITYID, FUNCTIONCODE, FUNCTIONNAME, FORMURL,ISMENU, MENUORDER, ISDELETED, RECORDSTATUS, CREATEDBY )
 values ('MobCargoHandling', 'MobCargoHandlingList', 'Cargo Handling', 'cargo-handling', 'Y', 50, 'N', 'A', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');

INSERT INTO usam.RoleFunction
(ROLEID,APPLICATIONENTITYID,FUNCTIONCODE,ISDELETED,RECORDSTATUS,CREATEDBY,CREATEDON,APPLICATIONID,SUBSCRIBERID) values
('Admin','MobCargoHandling','MobCargoHandlingList','N','A','1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0',sysdate,6,'KPCL');

insert into USAM.APPLICATIONENTITY(APPLICATIONENTITYID, APPLICATIONID, ENTITYNAME, FORMURL, ISMENU, MAILNOTIFICATION, SYSNOTIFICATION,
 SMS, WORKFLOW, MENUORDER, ISDELETED, RECORDSTATUS,MENUICON,Menuicon2, CREATEDBY ) 
values ('MobCargoHandling', 6, 'Cargo Handling', '', 'Y', 'N', 'N', 'N', 'N', 50, 'N','A','','', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');
--------------------------------------
--Approving Request for Storage Location
insert into USAM.APPLICATIONMODULEENTITY(MODULECODE, APPLICATIONENTITYID, MENUORDER, ISDELETED, RECORDSTATUS, CREATEDBY)
values ( 'PKMOBILE', 'MobApprovingRequestForStorageLocation', 25, 'N', 'A', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');

insert into usam.applicationentityfunction(APPLICATIONENTITYID, FUNCTIONCODE, FUNCTIONNAME, FORMURL,ISMENU, MENUORDER, ISDELETED, RECORDSTATUS, CREATEDBY )
 values ('MobApprovingRequestForStorageLocation', 'MobApprovingRequestForStorageLocationList', 'Approving Request for Storage Location', 'approving-request-for-storage-location', 'Y', 60, 'N', 'A', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');

INSERT INTO usam.RoleFunction
(ROLEID,APPLICATIONENTITYID,FUNCTIONCODE,ISDELETED,RECORDSTATUS,CREATEDBY,CREATEDON,APPLICATIONID,SUBSCRIBERID) values
('Admin','MobApprovingRequestForStorageLocation','MobApprovingRequestForStorageLocationList','N','A','1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0',sysdate,6,'KPCL');

insert into USAM.APPLICATIONENTITY(APPLICATIONENTITYID, APPLICATIONID, ENTITYNAME, FORMURL, ISMENU, MAILNOTIFICATION, SYSNOTIFICATION,
 SMS, WORKFLOW, MENUORDER, ISDELETED, RECORDSTATUS,MENUICON,Menuicon2, CREATEDBY ) 
values ('MobApprovingRequestForStorageLocation', 6, 'Approving Request for Storage Location', '', 'Y', 'N', 'N', 'N', 'N', 60, 'N','A','','', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');
--------------------------------------
--Request for Storage Location
insert into USAM.APPLICATIONMODULEENTITY(MODULECODE, APPLICATIONENTITYID, MENUORDER, ISDELETED, RECORDSTATUS, CREATEDBY)
values ( 'PKMOBILE', 'MobRequestForStorageLocation', 25, 'N', 'A', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');

insert into usam.applicationentityfunction(APPLICATIONENTITYID, FUNCTIONCODE, FUNCTIONNAME, FORMURL,ISMENU, MENUORDER, ISDELETED, RECORDSTATUS, CREATEDBY )
 values ('MobRequestForStorageLocation', 'MobRequestForStorageLocationList', 'Request for Storage Location', 'request-for-storage-location', 'Y', 55, 'N', 'A', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');

INSERT INTO usam.RoleFunction
(ROLEID,APPLICATIONENTITYID,FUNCTIONCODE,ISDELETED,RECORDSTATUS,CREATEDBY,CREATEDON,APPLICATIONID,SUBSCRIBERID) values
('Admin','MobRequestForStorageLocation','MobRequestForStorageLocationList','N','A','1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0',sysdate,6,'KPCL');

insert into USAM.APPLICATIONENTITY(APPLICATIONENTITYID, APPLICATIONID, ENTITYNAME, FORMURL, ISMENU, MAILNOTIFICATION, SYSNOTIFICATION,
 SMS, WORKFLOW, MENUORDER, ISDELETED, RECORDSTATUS,MENUICON,Menuicon2, CREATEDBY ) 
values ('MobRequestForStorageLocation', 6, 'Request for Storage Location', '', 'Y', 'N', 'N', 'N', 'N', 55, 'N','A','','', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');
--------------------------------------
--Raising Gang and Equipment Request
insert into USAM.APPLICATIONMODULEENTITY(MODULECODE, APPLICATIONENTITYID, MENUORDER, ISDELETED, RECORDSTATUS, CREATEDBY)
values ( 'PKMOBILE', 'MobRaisingGangEquipmentRequest', 25, 'N', 'A', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');

insert into usam.applicationentityfunction(APPLICATIONENTITYID, FUNCTIONCODE, FUNCTIONNAME, FORMURL,ISMENU, MENUORDER, ISDELETED, RECORDSTATUS, CREATEDBY )
 values ('MobRaisingGangEquipmentRequest', 'MobRaisingGangEquipmentRequestList', 'Raising Gang and Equipment Request', 'raising-gang-and-equipment-request', 'Y', 65, 'N', 'A', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');

INSERT INTO usam.RoleFunction
(ROLEID,APPLICATIONENTITYID,FUNCTIONCODE,ISDELETED,RECORDSTATUS,CREATEDBY,CREATEDON,APPLICATIONID,SUBSCRIBERID) values
('Admin','MobRaisingGangEquipmentRequest','MobRaisingGangEquipmentRequestList','N','A','1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0',sysdate,6,'KPCL');

insert into USAM.APPLICATIONENTITY(APPLICATIONENTITYID, APPLICATIONID, ENTITYNAME, FORMURL, ISMENU, MAILNOTIFICATION, SYSNOTIFICATION,
 SMS, WORKFLOW, MENUORDER, ISDELETED, RECORDSTATUS,MENUICON,Menuicon2, CREATEDBY ) 
values ('MobRaisingGangEquipmentRequest', 6, 'Raising Gang and Equipment Request', '', 'Y', 'N', 'N', 'N', 'N', 65, 'N','A','','', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');
--------------------------------------
--Approval for Raising Gang and Equipment Request
insert into USAM.APPLICATIONMODULEENTITY(MODULECODE, APPLICATIONENTITYID, MENUORDER, ISDELETED, RECORDSTATUS, CREATEDBY)
values ( 'PKMOBILE', 'MobApprovalRaisingGangEquipment', 25, 'N', 'A', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');

insert into usam.applicationentityfunction(APPLICATIONENTITYID, FUNCTIONCODE, FUNCTIONNAME, FORMURL,ISMENU, MENUORDER, ISDELETED, RECORDSTATUS, CREATEDBY )
 values ('MobApprovalRaisingGangEquipment', 'MobApprovalRaisingGangEquipmentList', 'Approval for Raising Gang and Equipment Request', 'approval-for-gang-and-equipment-request', 'Y', 70, 'N', 'A', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');

INSERT INTO usam.RoleFunction
(ROLEID,APPLICATIONENTITYID,FUNCTIONCODE,ISDELETED,RECORDSTATUS,CREATEDBY,CREATEDON,APPLICATIONID,SUBSCRIBERID) values
('Admin','MobApprovalRaisingGangEquipment','MobApprovalRaisingGangEquipmentList','N','A','1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0',sysdate,6,'KPCL');

insert into USAM.APPLICATIONENTITY(APPLICATIONENTITYID, APPLICATIONID, ENTITYNAME, FORMURL, ISMENU, MAILNOTIFICATION, SYSNOTIFICATION,
 SMS, WORKFLOW, MENUORDER, ISDELETED, RECORDSTATUS,MENUICON,Menuicon2, CREATEDBY ) 
values ('MobApprovalRaisingGangEquipment', 6, 'Approval for Raising Gang and Equipment Request', '', 'Y', 'N', 'N', 'N', 'N', 70, 'N','A','','', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');
--------------------------------------
--Request for Daily/Weekly Pass
insert into USAM.APPLICATIONMODULEENTITY(MODULECODE, APPLICATIONENTITYID, MENUORDER, ISDELETED, RECORDSTATUS, CREATEDBY)
values ( 'PKMOBILE', 'MobRequestDailyWeeklyPass', 25, 'N', 'A', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');

insert into usam.applicationentityfunction(APPLICATIONENTITYID, FUNCTIONCODE, FUNCTIONNAME, FORMURL,ISMENU, MENUORDER, ISDELETED, RECORDSTATUS, CREATEDBY )
 values ('MobRequestDailyWeeklyPass', 'MobRequestDailyWeeklyPassList', 'Request for Daily/Weekly Pass', 'request-for-daily-or-weekly-pass', 'Y', 75, 'N', 'A', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');

INSERT INTO usam.RoleFunction
(ROLEID,APPLICATIONENTITYID,FUNCTIONCODE,ISDELETED,RECORDSTATUS,CREATEDBY,CREATEDON,APPLICATIONID,SUBSCRIBERID) values
('Admin','MobRequestDailyWeeklyPass','MobRequestDailyWeeklyPassList','N','A','1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0',sysdate,6,'KPCL');

insert into USAM.APPLICATIONENTITY(APPLICATIONENTITYID, APPLICATIONID, ENTITYNAME, FORMURL, ISMENU, MAILNOTIFICATION, SYSNOTIFICATION,
 SMS, WORKFLOW, MENUORDER, ISDELETED, RECORDSTATUS,MENUICON,Menuicon2, CREATEDBY ) 
values ('MobRequestDailyWeeklyPass', 6, 'Request for Daily/Weekly Pass', '', 'Y', 'N', 'N', 'N', 'N', 75, 'N','A','','', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');
--------------------------------------
--Approval for Daily/Weekly Pass
insert into USAM.APPLICATIONMODULEENTITY(MODULECODE, APPLICATIONENTITYID, MENUORDER, ISDELETED, RECORDSTATUS, CREATEDBY)
values ( 'PKMOBILE', 'MobApprovalDailyWeeklyPass', 25, 'N', 'A', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');

insert into usam.applicationentityfunction(APPLICATIONENTITYID, FUNCTIONCODE, FUNCTIONNAME, FORMURL,ISMENU, MENUORDER, ISDELETED, RECORDSTATUS, CREATEDBY )
 values ('MobApprovalDailyWeeklyPass', 'MobApprovalDailyWeeklyPassList', 'Approval for Daily/Weekly Pass', 'approval-for-daily-or-weekly-pass', 'Y', 80, 'N', 'A', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');

INSERT INTO usam.RoleFunction
(ROLEID,APPLICATIONENTITYID,FUNCTIONCODE,ISDELETED,RECORDSTATUS,CREATEDBY,CREATEDON,APPLICATIONID,SUBSCRIBERID) values
('Admin','MobApprovalDailyWeeklyPass','MobApprovalDailyWeeklyPassList','N','A','1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0',sysdate,6,'KPCL');

insert into USAM.APPLICATIONENTITY(APPLICATIONENTITYID, APPLICATIONID, ENTITYNAME, FORMURL, ISMENU, MAILNOTIFICATION, SYSNOTIFICATION,
 SMS, WORKFLOW, MENUORDER, ISDELETED, RECORDSTATUS,MENUICON,Menuicon2, CREATEDBY ) 
values ('MobApprovalDailyWeeklyPass', 6, 'Approval for Daily/Weekly Pass', '', 'Y', 'N', 'N', 'N', 'N', 80, 'N','A','','', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');

---------------------------------------
insert into USAM.APPLICATIONMODULEENTITY(MODULECODE, APPLICATIONENTITYID, MENUORDER, ISDELETED, RECORDSTATUS, CREATEDBY)
values ( 'PKMOBILE', 'MobApprovingRI', 25, 'N', 'A', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');

insert into usam.applicationentityfunction(APPLICATIONENTITYID, FUNCTIONCODE, FUNCTIONNAME, FORMURL,ISMENU, MENUORDER, ISDELETED, RECORDSTATUS, CREATEDBY )
 values ('MobApprovingRI', 'MobApprovingRIList', 'Approving RI', 'approving-ri-list', 'Y', 85, 'N', 'A', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');

INSERT INTO usam.RoleFunction
(ROLEID,APPLICATIONENTITYID,FUNCTIONCODE,ISDELETED,RECORDSTATUS,CREATEDBY,CREATEDON,APPLICATIONID,SUBSCRIBERID) values
('Admin','MobApprovingRI','MobApprovingRIList','N','A','1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0',sysdate,6,'KPCL');

insert into USAM.APPLICATIONENTITY(APPLICATIONENTITYID, APPLICATIONID, ENTITYNAME, FORMURL, ISMENU, MAILNOTIFICATION, SYSNOTIFICATION,
 SMS, WORKFLOW, MENUORDER, ISDELETED, RECORDSTATUS,MENUICON,Menuicon2, CREATEDBY ) 
values ('MobApprovingRI', 6, 'Approving RI', '', 'Y', 'N', 'N', 'N', 'N', 85, 'N','A','','', '1ad9ad9e-9e1a-427b-b426-b1d4fef0a4f0');
