/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2014                    */
/* Created on:     14/01/2017 15:03:30                          */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CIUDAD') and o.name = 'FK_CIUDAD_PERTENECE_REGION')
alter table CIUDAD
   drop constraint FK_CIUDAD_PERTENECE_REGION
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CLIENTE') and o.name = 'FK_CLIENTE_TIENE2_ESTADO')
alter table CLIENTE
   drop constraint FK_CLIENTE_TIENE2_ESTADO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CLIENTE') and o.name = 'FK_CLIENTE_TIENE3_ROL')
alter table CLIENTE
   drop constraint FK_CLIENTE_TIENE3_ROL
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('COMUNA') and o.name = 'FK_COMUNA_PERTENECE_CIUDAD')
alter table COMUNA
   drop constraint FK_COMUNA_PERTENECE_CIUDAD
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('EMPLEADO') and o.name = 'FK_EMPLEADO_INCLUYE2_SUCURSAL')
alter table EMPLEADO
   drop constraint FK_EMPLEADO_INCLUYE2_SUCURSAL
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('EMPLEADO') and o.name = 'FK_EMPLEADO_UTILIZA_CARGO')
alter table EMPLEADO
   drop constraint FK_EMPLEADO_UTILIZA_CARGO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('EMPRESA') and o.name = 'FK_EMPRESA_ESTA_COMUNA')
alter table EMPRESA
   drop constraint FK_EMPRESA_ESTA_COMUNA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('REGION') and o.name = 'FK_REGION_PERTENECE_PAIS')
alter table REGION
   drop constraint FK_REGION_PERTENECE_PAIS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('RESERVA') and o.name = 'FK_RESERVA_INTEGRA2_TIEMPO_A')
alter table RESERVA
   drop constraint FK_RESERVA_INTEGRA2_TIEMPO_A
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('RESERVA') and o.name = 'FK_RESERVA_PERTENECE_CLIENTE')
alter table RESERVA
   drop constraint FK_RESERVA_PERTENECE_CLIENTE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('RESERVA') and o.name = 'FK_RESERVA_POSEE_SUCURSAL')
alter table RESERVA
   drop constraint FK_RESERVA_POSEE_SUCURSAL
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ROL') and o.name = 'FK_ROL_INTEGRA_PRIVILEG')
alter table ROL
   drop constraint FK_ROL_INTEGRA_PRIVILEG
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SUCURSAL') and o.name = 'FK_SUCURSAL_TIENE_CLASIFIC')
alter table SUCURSAL
   drop constraint FK_SUCURSAL_TIENE_CLASIFIC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SUCURSAL') and o.name = 'FK_SUCURSAL_TIENE4_EMPRESA')
alter table SUCURSAL
   drop constraint FK_SUCURSAL_TIENE4_EMPRESA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CARGO')
            and   type = 'U')
   drop table CARGO
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CIUDAD')
            and   name  = 'PERTENECE3_FK'
            and   indid > 0
            and   indid < 255)
   drop index CIUDAD.PERTENECE3_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CIUDAD')
            and   type = 'U')
   drop table CIUDAD
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CLASIFICACION')
            and   type = 'U')
   drop table CLASIFICACION
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CLIENTE')
            and   name  = 'TIENE2_FK'
            and   indid > 0
            and   indid < 255)
   drop index CLIENTE.TIENE2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CLIENTE')
            and   name  = 'TIENE3_FK'
            and   indid > 0
            and   indid < 255)
   drop index CLIENTE.TIENE3_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CLIENTE')
            and   type = 'U')
   drop table CLIENTE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('COMUNA')
            and   name  = 'PERTENECE2_FK'
            and   indid > 0
            and   indid < 255)
   drop index COMUNA.PERTENECE2_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('COMUNA')
            and   type = 'U')
   drop table COMUNA
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('EMPLEADO')
            and   name  = 'INCLUYE2_FK'
            and   indid > 0
            and   indid < 255)
   drop index EMPLEADO.INCLUYE2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('EMPLEADO')
            and   name  = 'UTILIZA_FK'
            and   indid > 0
            and   indid < 255)
   drop index EMPLEADO.UTILIZA_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('EMPLEADO')
            and   type = 'U')
   drop table EMPLEADO
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('EMPRESA')
            and   name  = 'ESTA_FK'
            and   indid > 0
            and   indid < 255)
   drop index EMPRESA.ESTA_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('EMPRESA')
            and   type = 'U')
   drop table EMPRESA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ESTADO')
            and   type = 'U')
   drop table ESTADO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PAIS')
            and   type = 'U')
   drop table PAIS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PRIVILEGIO')
            and   type = 'U')
   drop table PRIVILEGIO
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('REGION')
            and   name  = 'PERTENECE4_FK'
            and   indid > 0
            and   indid < 255)
   drop index REGION.PERTENECE4_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('REGION')
            and   type = 'U')
   drop table REGION
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('RESERVA')
            and   name  = 'POSEE_FK'
            and   indid > 0
            and   indid < 255)
   drop index RESERVA.POSEE_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('RESERVA')
            and   name  = 'PERTENECE_FK'
            and   indid > 0
            and   indid < 255)
   drop index RESERVA.PERTENECE_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('RESERVA')
            and   name  = 'INTEGRA2_FK'
            and   indid > 0
            and   indid < 255)
   drop index RESERVA.INTEGRA2_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('RESERVA')
            and   type = 'U')
   drop table RESERVA
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ROL')
            and   name  = 'INTEGRA_FK'
            and   indid > 0
            and   indid < 255)
   drop index ROL.INTEGRA_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ROL')
            and   type = 'U')
   drop table ROL
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('SUCURSAL')
            and   name  = 'TIENE_FK'
            and   indid > 0
            and   indid < 255)
   drop index SUCURSAL.TIENE_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('SUCURSAL')
            and   name  = 'TIENE4_FK'
            and   indid > 0
            and   indid < 255)
   drop index SUCURSAL.TIENE4_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SUCURSAL')
            and   type = 'U')
   drop table SUCURSAL
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TIEMPO_ATENCION')
            and   type = 'U')
   drop table TIEMPO_ATENCION
go

/*==============================================================*/
/* Table: CARGO                                                 */
/*==============================================================*/
create table CARGO (
   ID_CARGO             int                  identity,
   NOMBRE_CARGO         varchar(15)          not null,
   DESCRIPCION_CARGO    varchar(300)         null,
   constraint PK_CARGO primary key (ID_CARGO)
)
go

/*==============================================================*/
/* Table: CIUDAD                                                */
/*==============================================================*/
create table CIUDAD (
   ID_CIUDAD            int                  identity,
   ID_REGION            int                  null,
   NOMBRE_CIUDAD        varchar(25)          not null,
   constraint PK_CIUDAD primary key (ID_CIUDAD)
)
go

/*==============================================================*/
/* Index: PERTENECE3_FK                                         */
/*==============================================================*/




create nonclustered index PERTENECE3_FK on CIUDAD (ID_REGION ASC)
go

/*==============================================================*/
/* Table: CLASIFICACION                                         */
/*==============================================================*/
create table CLASIFICACION (
   ID_CLASIFICACION     int                  identity,
   NUMERO               varchar(4)           not null,
   HORA                 datetime             not null,
   constraint PK_CLASIFICACION primary key (ID_CLASIFICACION)
)
go

/*==============================================================*/
/* Table: CLIENTE                                               */
/*==============================================================*/
create table CLIENTE (
   ID_CLIENTE           int                  identity,
   ID_ESTADO            int                  null,
   ID_ROL               int                  null,
   NOMBRE               varchar(20)          not null,
   APPAT                varchar(15)          not null,
   APMAT                varchar(15)          not null,
   RUT                  varchar(10)          not null,
   DIRECCION            varchar(50)          not null,
   TELEFONO             int                  not null,
   EMAIL                varchar(30)          not null,
   USUARIO              varchar(15)          not null,
   PASS                 varchar(32)          not null,
   PREGUNTASEG1         varchar(30)          not null,
   RESPUESTASEG1        varchar(30)          not null,
   PREGUNTASEG2         varchar(30)          not null,
   RESPUESTASEG2        varchar(30)          not null,
   UCR_CLIENTE          int                  null,
   UAC_CLIENTE          int                  null,
   UEL_CLIENTE          int                  null,
   FCR_CLIENTE          datetime             null,
   FAC_CLIENTE          datetime             null,
   FEL_CLIENTE          datetime             null,
   constraint PK_CLIENTE primary key (ID_CLIENTE)
)
go

/*==============================================================*/
/* Index: TIENE3_FK                                             */
/*==============================================================*/




create nonclustered index TIENE3_FK on CLIENTE (ID_ROL ASC)
go

/*==============================================================*/
/* Index: TIENE2_FK                                             */
/*==============================================================*/




create nonclustered index TIENE2_FK on CLIENTE (ID_ESTADO ASC)
go

/*==============================================================*/
/* Table: COMUNA                                                */
/*==============================================================*/
create table COMUNA (
   ID_COMUNA            int                  identity,
   ID_CIUDAD            int                  null,
   NOMBRE_COMUNA        varchar(25)          not null,
   constraint PK_COMUNA primary key (ID_COMUNA)
)
go

/*==============================================================*/
/* Index: PERTENECE2_FK                                         */
/*==============================================================*/




create nonclustered index PERTENECE2_FK on COMUNA (ID_CIUDAD ASC)
go

/*==============================================================*/
/* Table: EMPLEADO                                              */
/*==============================================================*/
create table EMPLEADO (
   ID_EMPLEADO          int                  identity,
   ID_CARGO             int                  null,
   ID_SUCURSAL          int                  not null,
   NOMBRE_EMPLEADO      varchar(20)          not null,
   APPAT_EMPLEADO       varchar(15)          not null,
   APMAT_EMPLEADO       varchar(15)          not null,
   RUT_EMPLEADO         varchar(10)          not null,
   DIRECCION_EMPLEADO   varchar(50)          not null,
   TELEFONO_EMPLEADO    int                  not null,
   EMAIL_EMPLEADO       varchar(30)          not null,
   USUARIO_EMPLEADO     varchar(15)          not null,
   PASS_EMPLEADO        varchar(50)          not null,
   UCR_EMPLEADO         int                  not null,
   UAC_EMPLEADO         int                  null,
   UEL_EMPLEADO         int                  null,
   FCR_EMPLEADO         datetime             not null,
   FAC_EMPLEADO         datetime             null,
   FEL_EMPLEADO         datetime             null,
   constraint PK_EMPLEADO primary key (ID_EMPLEADO)
)
go

/*==============================================================*/
/* Index: UTILIZA_FK                                            */
/*==============================================================*/




create nonclustered index UTILIZA_FK on EMPLEADO (ID_CARGO ASC)
go

/*==============================================================*/
/* Index: INCLUYE2_FK                                           */
/*==============================================================*/




create nonclustered index INCLUYE2_FK on EMPLEADO (ID_SUCURSAL ASC)
go

/*==============================================================*/
/* Table: EMPRESA                                               */
/*==============================================================*/
create table EMPRESA (
   ID_EMPRESA           int                  identity,
   ID_COMUNA            int                  null,
   NOMBRE_EMPRESA       varchar(50)          not null,
   RUT_EMPRESA          varchar(10)          not null,
   DIRECCION_EMPRESA    varchar(50)          not null,
   RUBRO_EMPRESA        varchar(25)          not null,
   GIRO_EMPRESA         varchar(25)          not null,
   UCR_EMPRESA          int                  not null,
   CAC_EMPRESA          int                  null,
   UEL_EMPRESA          int                  null,
   FCR_EMPRESA          datetime             not null,
   FAC_EMPRESA          datetime             null,
   FEL_EMPRESA          datetime             null,
   constraint PK_EMPRESA primary key (ID_EMPRESA)
)
go

/*==============================================================*/
/* Index: ESTA_FK                                               */
/*==============================================================*/




create nonclustered index ESTA_FK on EMPRESA (ID_COMUNA ASC)
go

/*==============================================================*/
/* Table: ESTADO                                                */
/*==============================================================*/
create table ESTADO (
   ID_ESTADO            int                  identity,
   DESCRIPCION_ESTADO   varchar(15)          not null,
   constraint PK_ESTADO primary key (ID_ESTADO)
)
go

/*==============================================================*/
/* Table: PAIS                                                  */
/*==============================================================*/
create table PAIS (
   ID_PAIS              int                  identity,
   NOMBRE_PAIS          varchar(25)          not null,
   constraint PK_PAIS primary key (ID_PAIS)
)
go

/*==============================================================*/
/* Table: PRIVILEGIO                                            */
/*==============================================================*/
create table PRIVILEGIO (
   ID_PRIVILEGIO        int                  identity,
   NOMBRE_PRIVILEGIO    varchar(15)          not null,
   DESCRIPCION_PRIVILEGIO varchar(50)          not null,
   constraint PK_PRIVILEGIO primary key (ID_PRIVILEGIO)
)
go

/*==============================================================*/
/* Table: REGION                                                */
/*==============================================================*/
create table REGION (
   ID_REGION            int                  identity,
   ID_PAIS              int                  null,
   NOMBRE_REGION        varchar(25)          not null,
   constraint PK_REGION primary key (ID_REGION)
)
go

/*==============================================================*/
/* Index: PERTENECE4_FK                                         */
/*==============================================================*/




create nonclustered index PERTENECE4_FK on REGION (ID_PAIS ASC)
go

/*==============================================================*/
/* Table: RESERVA                                               */
/*==============================================================*/
create table RESERVA (
   ID_RESERVA           int                  identity,
   ID_SUCURSAL          int                  not null,
   ID_CLIENTE           int                  not null,
   ID_ATENCION          int                  null,
   TIPO_RESERVA         varchar(25)          not null,
   HORA_RESERVA         datetime             null,
   constraint PK_RESERVA primary key (ID_RESERVA)
)
go

/*==============================================================*/
/* Index: INTEGRA2_FK                                           */
/*==============================================================*/




create nonclustered index INTEGRA2_FK on RESERVA (ID_ATENCION ASC)
go

/*==============================================================*/
/* Index: PERTENECE_FK                                          */
/*==============================================================*/




create nonclustered index PERTENECE_FK on RESERVA (ID_CLIENTE ASC)
go

/*==============================================================*/
/* Index: POSEE_FK                                              */
/*==============================================================*/




create nonclustered index POSEE_FK on RESERVA (ID_SUCURSAL ASC)
go

/*==============================================================*/
/* Table: ROL                                                   */
/*==============================================================*/
create table ROL (
   ID_ROL               int                  identity,
   ID_PRIVILEGIO        int                  null,
   NOMBRE_ROL           varchar(15)          not null,
   constraint PK_ROL primary key (ID_ROL)
)
go

/*==============================================================*/
/* Index: INTEGRA_FK                                            */
/*==============================================================*/




create nonclustered index INTEGRA_FK on ROL (ID_PRIVILEGIO ASC)
go

/*==============================================================*/
/* Table: SUCURSAL                                              */
/*==============================================================*/
create table SUCURSAL (
   ID_SUCURSAL          int                  identity,
   ID_CLASIFICACION     int                  null,
   ID_EMPRESA           int                  null,
   NOMBRE_SUCURSAL      varchar(25)          not null,
   HORA_INICIO          time                 not null,
   HORA_TERMINO         time                 not null,
   LATITUD_SUCURSAL     decimal(20)          not null,
   LONGITUD_SUCURSAL    decimal(20)          not null,
   PRECISION_SUCURSAL   decimal(20)          not null,
   UCR_SUCURSAL         int                  not null,
   UAC_SUCURSAL         int                  null,
   UEL_SUCURSAL         int                  null,
   FCR_SUCURSAL         datetime             not null,
   FAC_SUCURSAL         datetime             null,
   FEL_SUCURSAL         datetime             null,
   constraint PK_SUCURSAL primary key (ID_SUCURSAL)
)
go

/*==============================================================*/
/* Index: TIENE4_FK                                             */
/*==============================================================*/




create nonclustered index TIENE4_FK on SUCURSAL (ID_EMPRESA ASC)
go

/*==============================================================*/
/* Index: TIENE_FK                                              */
/*==============================================================*/




create nonclustered index TIENE_FK on SUCURSAL (ID_CLASIFICACION ASC)
go

/*==============================================================*/
/* Table: TIEMPO_ATENCION                                       */
/*==============================================================*/
create table TIEMPO_ATENCION (
   ID_ATENCION          int                  identity,
   TIEMPO_ATENCION      datetime             not null,
   VALOR_ATENCION       int                  not null,
   constraint PK_TIEMPO_ATENCION primary key (ID_ATENCION)
)
go

alter table CIUDAD
   add constraint FK_CIUDAD_PERTENECE_REGION foreign key (ID_REGION)
      references REGION (ID_REGION)
go

alter table CLIENTE
   add constraint FK_CLIENTE_TIENE2_ESTADO foreign key (ID_ESTADO)
      references ESTADO (ID_ESTADO)
go

alter table CLIENTE
   add constraint FK_CLIENTE_TIENE3_ROL foreign key (ID_ROL)
      references ROL (ID_ROL)
go

alter table COMUNA
   add constraint FK_COMUNA_PERTENECE_CIUDAD foreign key (ID_CIUDAD)
      references CIUDAD (ID_CIUDAD)
go

alter table EMPLEADO
   add constraint FK_EMPLEADO_INCLUYE2_SUCURSAL foreign key (ID_SUCURSAL)
      references SUCURSAL (ID_SUCURSAL)
go

alter table EMPLEADO
   add constraint FK_EMPLEADO_UTILIZA_CARGO foreign key (ID_CARGO)
      references CARGO (ID_CARGO)
go

alter table EMPRESA
   add constraint FK_EMPRESA_ESTA_COMUNA foreign key (ID_COMUNA)
      references COMUNA (ID_COMUNA)
go

alter table REGION
   add constraint FK_REGION_PERTENECE_PAIS foreign key (ID_PAIS)
      references PAIS (ID_PAIS)
go

alter table RESERVA
   add constraint FK_RESERVA_INTEGRA2_TIEMPO_A foreign key (ID_ATENCION)
      references TIEMPO_ATENCION (ID_ATENCION)
go

alter table RESERVA
   add constraint FK_RESERVA_PERTENECE_CLIENTE foreign key (ID_CLIENTE)
      references CLIENTE (ID_CLIENTE)
go

alter table RESERVA
   add constraint FK_RESERVA_POSEE_SUCURSAL foreign key (ID_SUCURSAL)
      references SUCURSAL (ID_SUCURSAL)
go

alter table ROL
   add constraint FK_ROL_INTEGRA_PRIVILEG foreign key (ID_PRIVILEGIO)
      references PRIVILEGIO (ID_PRIVILEGIO)
go

alter table SUCURSAL
   add constraint FK_SUCURSAL_TIENE_CLASIFIC foreign key (ID_CLASIFICACION)
      references CLASIFICACION (ID_CLASIFICACION)
go

alter table SUCURSAL
   add constraint FK_SUCURSAL_TIENE4_EMPRESA foreign key (ID_EMPRESA)
      references EMPRESA (ID_EMPRESA)
go

