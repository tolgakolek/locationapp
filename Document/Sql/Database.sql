create table campus
(
  CampusID    int auto_increment
    primary key,
  Name        text charset utf8 null,
  Description text charset utf8 null,
  Other       text charset utf8 null
);

create table deviceroom
(
  DeviceRoomID int auto_increment
    primary key,
  RoomID       int         null,
  DeviceID     int         null,
  LocationX    varchar(45) null,
  LocationY    varchar(45) null,
  CreationDate date        null
);

create table devicetype
(
  DeviceTypeID int auto_increment
    primary key,
  Name         varchar(100) null
);

create table device
(
  DeviceID     int auto_increment
    primary key,
  Name         varchar(50)  null,
  Properties   varchar(200) null,
  Technology   varchar(200) null,
  DeviceTypeID int          null,
  constraint device_devicetype_DeviceTypeID_fk
    foreign key (DeviceTypeID) references devicetype (DeviceTypeID)
);

create table floor
(
  FloorID int auto_increment
    primary key,
  BlockID int                      null,
  BuildID int                      null,
  Name    varchar(50) charset utf8 null,
  Other   varchar(50) charset utf8 null,
  Map     varchar(50) charset utf8 null
);

create index floor_block_BlockID_fk
  on floor (BlockID);

create index floor_build_BuildID_fk
  on floor (BuildID);

create table mainunit
(
  MainUnitID int auto_increment
    primary key,
  Name       varchar(50) charset utf8 null
);

create table roomtype
(
  RoomTypeID  int auto_increment
    primary key,
  Name        varchar(50) charset utf8 null,
  Description varchar(50) charset utf8 null
);

create table room
(
  RoomID     int auto_increment
    primary key,
  FloorID    int                      null,
  Name       varchar(50) charset utf8 null,
  RoomTypeID int                      null,
  Map        varchar(50) charset utf8 null,
  constraint room_floor_FloorID_fk
    foreign key (FloorID) references floor (FloorID),
  constraint room_roomtype_RoomTypeID_fk
    foreign key (RoomTypeID) references roomtype (RoomTypeID)
);

create table senderrecieverdevicemobilbeacon
(
  ID                int auto_increment
    primary key,
  CreationDate      varchar(500) charset utf8 null,
  Device_Name_1     varchar(500) charset utf8 null,
  Device_Name_2     varchar(500) charset utf8 null,
  Device_Name_3     varchar(500) charset utf8 null,
  Device_Name_4     varchar(500) charset utf8 null,
  Device_RSS_1      varchar(500) charset utf8 null,
  Device_RSS_2      varchar(500) charset utf8 null,
  Device_RSS_3      varchar(500) charset utf8 null,
  Device_RSS_4      varchar(500) charset utf8 null,
  Device_Distance_1 varchar(500) charset utf8 null,
  Device_Distance_2 varchar(500) charset utf8 null,
  Device_Distance_3 varchar(500) charset utf8 null,
  Device_Distance_4 varchar(500) charset utf8 null,
  Point_Location    varchar(500) charset utf8 null
);

create table senderrecieverdevicemobilwifi
(
  ID                int auto_increment
    primary key,
  CreationDate      varchar(500) charset utf8 null,
  Device_Name_1     varchar(500) charset utf8 null,
  Device_Name_2     varchar(500) charset utf8 null,
  Device_Name_3     varchar(500) charset utf8 null,
  Device_Name_4     varchar(500) charset utf8 null,
  Device_RSS_1      varchar(500) charset utf8 null,
  Device_RSS_2      varchar(500) charset utf8 null,
  Device_RSS_3      varchar(500) charset utf8 null,
  Device_RSS_4      varchar(500) charset utf8 null,
  Device_Distance_1 varchar(500) charset utf8 null,
  Device_Distance_2 varchar(500) charset utf8 null,
  Device_Distance_3 varchar(500) charset utf8 null,
  Device_Distance_4 varchar(500) charset utf8 null,
  Point_Location    varchar(500) charset utf8 null
);

create table senderrecieverdevicenodemcuwifi
(
  ID                int auto_increment
    primary key,
  CreationDate      varchar(500) charset utf8 null,
  Device_Name_1     varchar(500) charset utf8 null,
  Device_Name_2     varchar(500) charset utf8 null,
  Device_Name_3     varchar(500) charset utf8 null,
  Device_Name_4     varchar(500) charset utf8 null,
  Device_RSS_1      varchar(500) charset utf8 null,
  Device_RSS_2      varchar(500) charset utf8 null,
  Device_RSS_3      varchar(500) charset utf8 null,
  Device_RSS_4      varchar(500) charset utf8 null,
  Device_Distance_1 varchar(500) charset utf8 null,
  Device_Distance_2 varchar(500) charset utf8 null,
  Device_Distance_3 varchar(500) charset utf8 null,
  Device_Distance_4 varchar(500) charset utf8 null,
  Point_Location    varchar(500) charset utf8 null
);

create table senderrecieverdeviceraspberrybeacon
(
  ID                int auto_increment
    primary key,
  CreationDate      varchar(500) charset utf8 null,
  Device_Name_1     varchar(500) charset utf8 null,
  Device_Name_2     varchar(500) charset utf8 null,
  Device_Name_3     varchar(500) charset utf8 null,
  Device_Name_4     varchar(500) charset utf8 null,
  Device_RSS_1      varchar(500) charset utf8 null,
  Device_RSS_2      varchar(500) charset utf8 null,
  Device_RSS_3      varchar(500) charset utf8 null,
  Device_RSS_4      varchar(500) charset utf8 null,
  Device_Distance_1 varchar(500) charset utf8 null,
  Device_Distance_2 varchar(500) charset utf8 null,
  Device_Distance_3 varchar(500) charset utf8 null,
  Device_Distance_4 varchar(500) charset utf8 null,
  Point_Location    varchar(500) charset utf8 null
);

create table site
(
  SiteID      int auto_increment
    primary key,
  Name        varchar(50) charset utf8 null,
  Description varchar(50) charset utf8 null,
  Gps         varchar(50) charset utf8 null
);

create table build
(
  BuildID    int auto_increment
    primary key,
  SiteID     int                       null,
  Name       varchar(50) charset utf8  null,
  Adress     varchar(150) charset utf8 null,
  Gps        varchar(50) charset utf8  null,
  Properties varchar(150) charset utf8 null,
  CampusID   int                       null,
  constraint build_campus_CampusID_fk
    foreign key (CampusID) references campus (CampusID),
  constraint build_site_SiteID_fk
    foreign key (SiteID) references site (SiteID)
);

create table block
(
  BlockID int auto_increment
    primary key,
  BuildID int                      null,
  Name    varchar(50) charset utf8 null,
  Gps     varchar(50) charset utf8 null,
  constraint block_build_BuildID_fk
    foreign key (BuildID) references build (BuildID)
);

create table campussite
(
  CampusSiteID int auto_increment
    primary key,
  SiteID       int                      not null,
  CampusID     int                      not null,
  Other        varchar(50) charset utf8 null,
  constraint campussite_campus_CampusID_fk
    foreign key (CampusID) references campus (CampusID),
  constraint campussite_site_SiteID_fk
    foreign key (SiteID) references site (SiteID)
);

create table subunit
(
  SubUnitID  int auto_increment
    primary key,
  Name       varchar(50) charset utf8 null,
  MainUnitID int                      null,
  constraint Fk_MainUnitID
    foreign key (MainUnitID) references mainunit (MainUnitID)
);

create table department
(
  DepartmentID int auto_increment
    primary key,
  Name         varchar(50) charset utf8  null,
  Description  varchar(50) charset utf8  null,
  Other        varchar(100) charset utf8 null,
  SubUnitID    int                       null,
  constraint FK_SubUnitID
    foreign key (SubUnitID) references subunit (SubUnitID)
);

create table departmentroom
(
  DepartmentRoomID int auto_increment
    primary key,
  RoomID           int                      null,
  DepartmentID     int                      null,
  Other            varchar(50) charset utf8 null,
  constraint departmentroom_department_DepartmentID_fk
    foreign key (DepartmentID) references department (DepartmentID),
  constraint departmentroom_room_RoomID_fk
    foreign key (RoomID) references room (RoomID)
);

create table usercontacttype
(
  UserContactTypeID int auto_increment
    primary key,
  TypeName          varchar(50) charset utf8 null,
  Description       varchar(50) charset utf8 null
);

create table userrole
(
  UserRoleID          int auto_increment
    primary key,
  UserRoleName        varchar(50) charset utf8 null,
  UserRoleDescription varchar(50) charset utf8 null,
  Active              tinyint(1)               null
);

create table usertitle
(
  UserTitleID int auto_increment
    primary key,
  TitleName   varchar(50) charset utf8 null
);

create table user
(
  UserID      int auto_increment
    primary key,
  Name        varchar(50) charset utf8 null,
  SurName     varchar(50) charset utf8 null,
  Gender      varchar(50)              null,
  NationID    text                     null,
  UserTitleID int                      null,
  constraint user_usertitle_UserTitleID_fk
    foreign key (UserTitleID) references usertitle (UserTitleID)
);

create table deviceuser
(
  DeviceUserID int auto_increment
    primary key,
  DeviceID     int null,
  UserID       int null,
  constraint deviceuser_user_UserID_fk
    foreign key (UserID) references user (UserID)
);

create table usercontact
(
  UserContactID     int auto_increment
    primary key,
  Contact           varchar(50) charset utf8 null,
  UserID            int                      null,
  UserContactTypeID int                      null,
  constraint usercontact_user_UserID_fk
    foreign key (UserID) references user (UserID),
  constraint usercontact_usercontacttype_UserContactTypeID_fk
    foreign key (UserContactTypeID) references usercontacttype (UserContactTypeID)
);

create table userdepartment
(
  UserDepartmentID int auto_increment
    primary key,
  UserID           int null,
  DepartmentID     int null,
  constraint FK_DepartmentID
    foreign key (DepartmentID) references department (DepartmentID),
  constraint userdepartment_user_UserID_fk
    foreign key (UserID) references user (UserID)
);

create table userlogin
(
  UserLoginID  int auto_increment
    primary key,
  Password     varchar(50) charset utf8 null,
  CreationDate date                     null,
  IpAdress     varchar(20) charset utf8 null,
  UserID       int                      null,
  constraint userlogin_user_UserID_fk
    foreign key (UserID) references user (UserID)
);

create table userpassword
(
  UserPasswordID int auto_increment
    primary key,
  Password       varchar(20) charset utf8 null,
  UserID         int                      null,
  constraint userpassword_user_UserID_fk
    foreign key (UserID) references user (UserID)
);

create table useruserrole
(
  UserUserRoleID int auto_increment
    primary key,
  UserID         int null,
  UserRoleID     int null,
  constraint FK_UserRoleID
    foreign key (UserRoleID) references userrole (UserRoleID),
  constraint useruserrole_user_UserID_fk
    foreign key (UserID) references user (UserID)
);

