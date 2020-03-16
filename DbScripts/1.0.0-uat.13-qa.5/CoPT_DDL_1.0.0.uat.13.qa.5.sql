
spool  CoPT_DDL_1.0.0.uat.13.qa.5.log

Set SCAN off;

CREATE OR REPLACE FORCE VIEW USAM.EV_MODULESENTITYFUNCTIONS
(
   APPLICATIONID,
   MODULECODE,
   MODULENAME,
   MODULEICON,
   PARENTMODULECODE,
   MODULEORDER,
   APPLICATIONENTITYID,
   ENTITYNAME,
   ENTITYORDER,
   FUNCTIONCODE,
   FUNCTIONNAME,
   ISMENU,
   FORMURL,
   ENTITYURL,
   FUNCTIONORDER,
   MODULEURL,
   MENUICON,
   MENUICON1,
   MENUICON2
)
   BEQUEATH DEFINER
AS
     SELECT am.APPLICATIONID AS APPLICATIONID,
            am.MODULECODE AS MODULECODE,
            am.MODULENAME AS MODULENAME,
            am.MODULEICON AS MODULEICON,
            am.PARENTMODULECODE AS PARENTMODULECODE,
            am.MENUORDER AS MODULEORDER,
            ae.APPLICATIONENTITYID AS APPLICATIONENTITYID,
            ae.ENTITYNAME AS ENTITYNAME,
            ae.MENUORDER AS ENTITYORDER,
            aef.FUNCTIONCODE AS FUNCTIONCODE,
            aef.FUNCTIONNAME AS FUNCTIONNAME,
			aef.ISMENU AS ISMENU,
            aef.FORMURL AS FORMURL,
            ae.FORMURL AS ENTITYURL,
            aef.MENUORDER AS FUNCTIONORDER,
            am.MODULEURL,
            ae.MenuIcon AS MENUICON,
            ae.MenuIcon1 AS MENUICON1,
            ae.MenuIcon2 AS MENUICON2
       FROM (((usam.applicationmodule am
               JOIN usam.applicationmoduleentity ame
                  ON ( (am.MODULECODE = ame.MODULECODE)))
              JOIN usam.applicationentity ae
                 ON ( (    (ae.APPLICATIONENTITYID = ame.APPLICATIONENTITYID)
                       AND (ae.APPLICATIONID = am.APPLICATIONID))))
             JOIN usam.applicationentityfunction aef
                ON ( (aef.APPLICATIONENTITYID = ae.APPLICATIONENTITYID)))
      WHERE ( (ae.ISMENU = 'Y')
             AND (ame.ISDELETED = 'N')
             AND (ae.ISDELETED = 'N')
             AND (aef.ISDELETED = 'N')
             AND am.RECORDSTATUS = 'A')
   ORDER BY am.MENUORDER, ae.MENUORDER, aef.MENUORDER;
   
Set SCAN on;

spool off
