
USE locationapp
SET FOREIGN_KEY_CHECKS = 0; -- foreignkey'leri iptal eder
SET AUTOCOMMIT = 0; -- commit kontrollerini iptal eder
START TRANSACTION; -- başlıyor


DELETE FROM block;
ALTER TABLE block AUTO_INCREMENT = 1;

DELETE FROM build;
ALTER TABLE build AUTO_INCREMENT = 1;

DELETE FROM campus;
ALTER TABLE campus AUTO_INCREMENT = 1;

DELETE FROM campussite;
ALTER TABLE campussite AUTO_INCREMENT = 1;

DELETE FROM department;
ALTER TABLE department AUTO_INCREMENT = 1;

DELETE FROM departmentroom;
ALTER TABLE departmentroom AUTO_INCREMENT = 1;

DELETE FROM floor;
ALTER TABLE floor AUTO_INCREMENT = 1;

DELETE FROM mainunit;
ALTER TABLE mainunit AUTO_INCREMENT = 1;

DELETE FROM room;
ALTER TABLE room AUTO_INCREMENT = 1;

DELETE FROM roomtype;
ALTER TABLE roomtype AUTO_INCREMENT = 1;

DELETE FROM site;
ALTER TABLE site AUTO_INCREMENT = 1;

DELETE FROM subunit;
ALTER TABLE subunit AUTO_INCREMENT = 1;

DELETE FROM user;
ALTER TABLE user AUTO_INCREMENT = 1;

DELETE FROM usercontact;
ALTER TABLE usercontact AUTO_INCREMENT = 1;

DELETE FROM userdepartment;
ALTER TABLE userdepartment AUTO_INCREMENT = 1;

DELETE FROM userlogin;
ALTER TABLE userlogin AUTO_INCREMENT = 1;

DELETE FROM userpassword;
ALTER TABLE userpassword AUTO_INCREMENT = 1;

DELETE FROM userrole;
ALTER TABLE userrole AUTO_INCREMENT = 1;

DELETE FROM usertitle;
ALTER TABLE usertitle AUTO_INCREMENT = 1;

DELETE FROM useruserrole;
ALTER TABLE useruserrole AUTO_INCREMENT = 1;

SET FOREIGN_KEY_CHECKS = 1; -- foreign keyleri aktif eder
COMMIT;  -- değişiklikleri onaylar
SET AUTOCOMMIT = 1 ;