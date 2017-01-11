/*==============================================================*/
/* DBMS name:      SAP SQL Anywhere 16                          */
/* Created on:     09/01/2017 0:00:01                           */
/*==============================================================*/


if exists(select 1 from sys.sysforeignkey where role='FK_CIUDAD_PERTENECE_REGION') then
    alter table CIUDAD
       delete foreign key FK_CIUDAD_PERTENECE_REGION
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_CLIENTE_TIENE2_ESTADO') then
    alter table CLIENTE
       delete foreign key FK_CLIENTE_TIENE2_ESTADO
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_CLIENTE_TIENE3_ROL') then
    alter table CLIENTE
       delete foreign key FK_CLIENTE_TIENE3_ROL
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_COMUNA_PERTENECE_CIUDAD') then
    alter table COMUNA
       delete foreign key FK_COMUNA_PERTENECE_CIUDAD
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_EMPLEADO_INCLUYE2_SUCURSAL') then
    alter table EMPLEADO
       delete foreign key FK_EMPLEADO_INCLUYE2_SUCURSAL
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_EMPLEADO_UTILIZA_CARGO') then
    alter table EMPLEADO
       delete foreign key FK_EMPLEADO_UTILIZA_CARGO
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_EMPRESA_ESTA_COMUNA') then
    alter table EMPRESA
       delete foreign key FK_EMPRESA_ESTA_COMUNA
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_REGION_PERTENECE_PAIS') then
    alter table REGION
       delete foreign key FK_REGION_PERTENECE_PAIS
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_RESERVA_INTEGRA2_TIEMPO_A') then
    alter table RESERVA
       delete foreign key FK_RESERVA_INTEGRA2_TIEMPO_A
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_RESERVA_PERTENECE_CLIENTE') then
    alter table RESERVA
       delete foreign key FK_RESERVA_PERTENECE_CLIENTE
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_RESERVA_POSEE_SUCURSAL') then
    alter table RESERVA
       delete foreign key FK_RESERVA_POSEE_SUCURSAL
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_ROL_INTEGRA_PRIVILEG') then
    alter table ROL
       delete foreign key FK_ROL_INTEGRA_PRIVILEG
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_SUCURSAL_TIENE_CLASIFIC') then
    alter table SUCURSAL
       delete foreign key FK_SUCURSAL_TIENE_CLASIFIC
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_SUCURSAL_TIENE4_EMPRESA') then
    alter table SUCURSAL
       delete foreign key FK_SUCURSAL_TIENE4_EMPRESA
end if;

drop index if exists CARGO.CARGO_PK;

drop table if exists CARGO;

drop index if exists CIUDAD.PERTENECE3_FK;

drop index if exists CIUDAD.CIUDAD_PK;

drop table if exists CIUDAD;

drop index if exists CLASIFICACION.CLASIFICACION_PK;

drop table if exists CLASIFICACION;

drop index if exists CLIENTE.TIENE2_FK;

drop index if exists CLIENTE.TIENE3_FK;

drop index if exists CLIENTE.CLIENTE_PK;

drop table if exists CLIENTE;

drop index if exists COMUNA.PERTENECE2_FK;

drop index if exists COMUNA.COMUNA_PK;

drop table if exists COMUNA;

drop index if exists EMPLEADO.INCLUYE2_FK;

drop index if exists EMPLEADO.UTILIZA_FK;

drop index if exists EMPLEADO.EMPLEADO_PK;

drop table if exists EMPLEADO;

drop index if exists EMPRESA.ESTA_FK;

drop index if exists EMPRESA.EMPRESA_PK;

drop table if exists EMPRESA;

drop index if exists ESTADO.ESTADO_PK;

drop table if exists ESTADO;

drop index if exists PAIS.PAIS_PK;

drop table if exists PAIS;

drop index if exists PRIVILEGIO.PRIVILEGIO_PK;

drop table if exists PRIVILEGIO;

drop index if exists REGION.PERTENECE4_FK;

drop index if exists REGION.REGION_PK;

drop table if exists REGION;

drop index if exists RESERVA.POSEE_FK;

drop index if exists RESERVA.PERTENECE_FK;

drop index if exists RESERVA.INTEGRA2_FK;

drop index if exists RESERVA.RESERVA_PK;

drop table if exists RESERVA;

drop index if exists ROL.INTEGRA_FK;

drop index if exists ROL.ROL_PK;

drop table if exists ROL;

drop index if exists SUCURSAL.TIENE_FK;

drop index if exists SUCURSAL.TIENE4_FK;

drop index if exists SUCURSAL.SUCURSAL_PK;

drop table if exists SUCURSAL;

drop index if exists TIEMPO_ATENCION.TIEMPO_ATENCION_PK;

drop table if exists TIEMPO_ATENCION;

/*==============================================================*/
/* Table: CARGO                                                 */
/*==============================================================*/
create table CARGO 
(
   ID_CARGO             integer                        not null,
   NOMBRE_CARGO         varchar(15)                    not null,
   DESCRIPCION_CARGO    varchar(300)                   null,
   constraint PK_CARGO primary key clustered (ID_CARGO)
);

/*==============================================================*/
/* Index: CARGO_PK                                              */
/*==============================================================*/
create unique clustered index CARGO_PK on CARGO (
ID_CARGO ASC
);

/*==============================================================*/
/* Table: CIUDAD                                                */
/*==============================================================*/
create table CIUDAD 
(
   ID_CIUDAD            integer                        not null,
   ID_REGION            integer                        null,
   NOMBRE_CIUDAD        varchar(25)                    not null,
   constraint PK_CIUDAD primary key clustered (ID_CIUDAD)
);

/*==============================================================*/
/* Index: CIUDAD_PK                                             */
/*==============================================================*/
create unique clustered index CIUDAD_PK on CIUDAD (
ID_CIUDAD ASC
);

/*==============================================================*/
/* Index: PERTENECE3_FK                                         */
/*==============================================================*/
create index PERTENECE3_FK on CIUDAD (
ID_REGION ASC
);

/*==============================================================*/
/* Table: CLASIFICACION                                         */
/*==============================================================*/
create table CLASIFICACION 
(
   ID_CLASIFICACION     integer                        not null,
   NUMERO               varchar(4)                     not null,
   HORA                 time                           not null,
   constraint PK_CLASIFICACION primary key clustered (ID_CLASIFICACION)
);

/*==============================================================*/
/* Index: CLASIFICACION_PK                                      */
/*==============================================================*/
create unique clustered index CLASIFICACION_PK on CLASIFICACION (
ID_CLASIFICACION ASC
);

/*==============================================================*/
/* Table: CLIENTE                                               */
/*==============================================================*/
create table CLIENTE 
(
   ID_CLIENTE           integer                        not null,
   ID_ESTADO            integer                        null,
   ID_ROL               integer                        null,
   NOMBRE               varchar(20)                    not null,
   APPAT                varchar(15)                    not null,
   APMAT                varchar(15)                    not null,
   RUT                  varchar(10)                    not null,
   DIRECCION            varchar(50)                    not null,
   TELEFONO             integer                        not null,
   EMAIL                varchar(30)                    not null,
   USUARIO              varchar(15)                    not null,
   PASS                 varchar(18)                    not null,
   PREGUNTASEG1         varchar(30)                    not null,
   RESPUESTASEG1        varchar(30)                    not null,
   PREGUNTASEG2         varchar(30)                    not null,
   RESPUESTASEG2        varchar(30)                    not null,
   UCR_CLIENTE          integer                        null,
   UAC_CLIENTE          integer                        null,
   UEL_CLIENTE          integer                        null,
   FCR_CLIENTE          timestamp                      null,
   FAC_CLIENTE          timestamp                      null,
   FEL_CLIENTE          timestamp                      null,
   constraint PK_CLIENTE primary key clustered (ID_CLIENTE)
);

/*==============================================================*/
/* Index: CLIENTE_PK                                            */
/*==============================================================*/
create unique clustered index CLIENTE_PK on CLIENTE (
ID_CLIENTE ASC
);

/*==============================================================*/
/* Index: TIENE3_FK                                             */
/*==============================================================*/
create index TIENE3_FK on CLIENTE (
ID_ROL ASC
);

/*==============================================================*/
/* Index: TIENE2_FK                                             */
/*==============================================================*/
create index TIENE2_FK on CLIENTE (
ID_ESTADO ASC
);

/*==============================================================*/
/* Table: COMUNA                                                */
/*==============================================================*/
create table COMUNA 
(
   ID_COMUNA            integer                        not null,
   ID_CIUDAD            integer                        null,
   NOMBRE_COMUNA        varchar(25)                    not null,
   constraint PK_COMUNA primary key clustered (ID_COMUNA)
);

/*==============================================================*/
/* Index: COMUNA_PK                                             */
/*==============================================================*/
create unique clustered index COMUNA_PK on COMUNA (
ID_COMUNA ASC
);

/*==============================================================*/
/* Index: PERTENECE2_FK                                         */
/*==============================================================*/
create index PERTENECE2_FK on COMUNA (
ID_CIUDAD ASC
);

/*==============================================================*/
/* Table: EMPLEADO                                              */
/*==============================================================*/
create table EMPLEADO 
(
   ID_EMPLEADO          integer                        not null,
   ID_CARGO             integer                        null,
   ID_SUCURSAL          integer                        not null,
   NOMBRE_EMPLEADO      varchar(20)                    not null,
   APPAT_EMPLEADO       varchar(15)                    not null,
   APMAT_EMPLEADO       varchar(15)                    not null,
   RUT_EMPLEADO         varchar(10)                    not null,
   DIRECCION_EMPLEADO   varchar(50)                    not null,
   TELEFONO_EMPLEADO    integer                        not null,
   EMAIL_EMPLEADO       varchar(30)                    not null,
   USUARIO_EMPLEADO     varchar(15)                    not null,
   PASS_EMPLEADO        varchar(50)                    not null,
   UCR_EMPLEADO         integer                        not null,
   UAC_EMPLEADO         integer                        null,
   UEL_EMPLEADO         integer                        null,
   FCR_EMPLEADO         timestamp                      not null,
   FAC_EMPLEADO         timestamp                      null,
   FEL_EMPLEADO         timestamp                      null,
   constraint PK_EMPLEADO primary key clustered (ID_EMPLEADO)
);

/*==============================================================*/
/* Index: EMPLEADO_PK                                           */
/*==============================================================*/
create unique clustered index EMPLEADO_PK on EMPLEADO (
ID_EMPLEADO ASC
);

/*==============================================================*/
/* Index: UTILIZA_FK                                            */
/*==============================================================*/
create index UTILIZA_FK on EMPLEADO (
ID_CARGO ASC
);

/*==============================================================*/
/* Index: INCLUYE2_FK                                           */
/*==============================================================*/
create index INCLUYE2_FK on EMPLEADO (
ID_SUCURSAL ASC
);

/*==============================================================*/
/* Table: EMPRESA                                               */
/*==============================================================*/
create table EMPRESA 
(
   ID_EMPRESA           integer                        not null,
   ID_COMUNA            integer                        null,
   NOMBRE_EMPRESA       varchar(50)                    not null,
   RUT_EMPRESA          varchar(10)                    not null,
   DIRECCION_EMPRESA    varchar(50)                    not null,
   RUBRO_EMPRESA        varchar(25)                    not null,
   GIRO_EMPRESA         varchar(25)                    not null,
   UCR_EMPRESA          integer                        not null,
   CAC_EMPRESA          integer                        null,
   UEL_EMPRESA          integer                        null,
   FCR_EMPRESA          timestamp                      not null,
   FAC_EMPRESA          timestamp                      null,
   FEL_EMPRESA          timestamp                      null,
   constraint PK_EMPRESA primary key clustered (ID_EMPRESA)
);

/*==============================================================*/
/* Index: EMPRESA_PK                                            */
/*==============================================================*/
create unique clustered index EMPRESA_PK on EMPRESA (
ID_EMPRESA ASC
);

/*==============================================================*/
/* Index: ESTA_FK                                               */
/*==============================================================*/
create index ESTA_FK on EMPRESA (
ID_COMUNA ASC
);

/*==============================================================*/
/* Table: ESTADO                                                */
/*==============================================================*/
create table ESTADO 
(
   ID_ESTADO            integer                        not null,
   DESCRIPCION_ESTADO   varchar(15)                    not null,
   constraint PK_ESTADO primary key clustered (ID_ESTADO)
);

/*==============================================================*/
/* Index: ESTADO_PK                                             */
/*==============================================================*/
create unique clustered index ESTADO_PK on ESTADO (
ID_ESTADO ASC
);

/*==============================================================*/
/* Table: PAIS                                                  */
/*==============================================================*/
create table PAIS 
(
   ID_PAIS              integer                        not null,
   NOMBRE_PAIS          varchar(25)                    not null,
   constraint PK_PAIS primary key clustered (ID_PAIS)
);

/*==============================================================*/
/* Index: PAIS_PK                                               */
/*==============================================================*/
create unique clustered index PAIS_PK on PAIS (
ID_PAIS ASC
);

/*==============================================================*/
/* Table: PRIVILEGIO                                            */
/*==============================================================*/
create table PRIVILEGIO 
(
   ID_PRIVILEGIO        integer                        not null,
   NOMBRE_PRIVILEGIO    varchar(15)                    not null,
   DESCRIPCION_PRIVILEGIO varchar(50)                    not null,
   constraint PK_PRIVILEGIO primary key clustered (ID_PRIVILEGIO)
);

/*==============================================================*/
/* Index: PRIVILEGIO_PK                                         */
/*==============================================================*/
create unique clustered index PRIVILEGIO_PK on PRIVILEGIO (
ID_PRIVILEGIO ASC
);

/*==============================================================*/
/* Table: REGION                                                */
/*==============================================================*/
create table REGION 
(
   ID_REGION            integer                        not null,
   ID_PAIS              integer                        null,
   NOMBRE_REGION        varchar(25)                    not null,
   constraint PK_REGION primary key clustered (ID_REGION)
);

/*==============================================================*/
/* Index: REGION_PK                                             */
/*==============================================================*/
create unique clustered index REGION_PK on REGION (
ID_REGION ASC
);

/*==============================================================*/
/* Index: PERTENECE4_FK                                         */
/*==============================================================*/
create index PERTENECE4_FK on REGION (
ID_PAIS ASC
);

/*==============================================================*/
/* Table: RESERVA                                               */
/*==============================================================*/
create table RESERVA 
(
   ID_RESERVA           integer                        not null,
   ID_SUCURSAL          integer                        not null,
   ID_CLIENTE           integer                        not null,
   ID_ATENCION          integer                        null,
   TIPO_RESERVA         varchar(25)                    not null,
   HORA_RESERVA         time                           null,
   constraint PK_RESERVA primary key clustered (ID_RESERVA)
);

/*==============================================================*/
/* Index: RESERVA_PK                                            */
/*==============================================================*/
create unique clustered index RESERVA_PK on RESERVA (
ID_RESERVA ASC
);

/*==============================================================*/
/* Index: INTEGRA2_FK                                           */
/*==============================================================*/
create index INTEGRA2_FK on RESERVA (
ID_ATENCION ASC
);

/*==============================================================*/
/* Index: PERTENECE_FK                                          */
/*==============================================================*/
create index PERTENECE_FK on RESERVA (
ID_CLIENTE ASC
);

/*==============================================================*/
/* Index: POSEE_FK                                              */
/*==============================================================*/
create index POSEE_FK on RESERVA (
ID_SUCURSAL ASC
);

/*==============================================================*/
/* Table: ROL                                                   */
/*==============================================================*/
create table ROL 
(
   ID_ROL               integer                        not null,
   ID_PRIVILEGIO        integer                        null,
   NOMBRE_ROL           varchar(15)                    not null,
   constraint PK_ROL primary key clustered (ID_ROL)
);

/*==============================================================*/
/* Index: ROL_PK                                                */
/*==============================================================*/
create unique clustered index ROL_PK on ROL (
ID_ROL ASC
);

/*==============================================================*/
/* Index: INTEGRA_FK                                            */
/*==============================================================*/
create index INTEGRA_FK on ROL (
ID_PRIVILEGIO ASC
);

/*==============================================================*/
/* Table: SUCURSAL                                              */
/*==============================================================*/
create table SUCURSAL 
(
   ID_SUCURSAL          integer                        not null,
   ID_CLASIFICACION     integer                        null,
   ID_EMPRESA           integer                        null,
   NOMBRE_SUCURSAL      varchar(25)                    not null,
   LATITUD_SUCURSAL     decimal(20)                    not null,
   LONGITUD_SUCURSAL    decimal(20)                    not null,
   PRECISION_SUCURSAL   decimal(20)                    not null,
   UCR_SUCURSAL         integer                        not null,
   UAC_SUCURSAL         integer                        null,
   UEL_SUCURSAL         integer                        null,
   FCR_SUCURSAL         timestamp                      not null,
   FAC_SUCURSAL         timestamp                      null,
   FEL_SUCURSAL         timestamp                      null,
   constraint PK_SUCURSAL primary key clustered (ID_SUCURSAL)
);

/*==============================================================*/
/* Index: SUCURSAL_PK                                           */
/*==============================================================*/
create unique clustered index SUCURSAL_PK on SUCURSAL (
ID_SUCURSAL ASC
);

/*==============================================================*/
/* Index: TIENE4_FK                                             */
/*==============================================================*/
create index TIENE4_FK on SUCURSAL (
ID_EMPRESA ASC
);

/*==============================================================*/
/* Index: TIENE_FK                                              */
/*==============================================================*/
create index TIENE_FK on SUCURSAL (
ID_CLASIFICACION ASC
);

/*==============================================================*/
/* Table: TIEMPO_ATENCION                                       */
/*==============================================================*/
create table TIEMPO_ATENCION 
(
   ID_ATENCION          integer                        not null,
   TIEMPO_ATENCION      time                           not null,
   VALOR_ATENCION       integer                        not null,
   constraint PK_TIEMPO_ATENCION primary key clustered (ID_ATENCION)
);

/*==============================================================*/
/* Index: TIEMPO_ATENCION_PK                                    */
/*==============================================================*/
create unique clustered index TIEMPO_ATENCION_PK on TIEMPO_ATENCION (
ID_ATENCION ASC
);

alter table CIUDAD
   add constraint FK_CIUDAD_PERTENECE_REGION foreign key (ID_REGION)
      references REGION (ID_REGION)
      on update restrict
      on delete restrict;

alter table CLIENTE
   add constraint FK_CLIENTE_TIENE2_ESTADO foreign key (ID_ESTADO)
      references ESTADO (ID_ESTADO)
      on update restrict
      on delete restrict;

alter table CLIENTE
   add constraint FK_CLIENTE_TIENE3_ROL foreign key (ID_ROL)
      references ROL (ID_ROL)
      on update restrict
      on delete restrict;

alter table COMUNA
   add constraint FK_COMUNA_PERTENECE_CIUDAD foreign key (ID_CIUDAD)
      references CIUDAD (ID_CIUDAD)
      on update restrict
      on delete restrict;

alter table EMPLEADO
   add constraint FK_EMPLEADO_INCLUYE2_SUCURSAL foreign key (ID_SUCURSAL)
      references SUCURSAL (ID_SUCURSAL)
      on update restrict
      on delete restrict;

alter table EMPLEADO
   add constraint FK_EMPLEADO_UTILIZA_CARGO foreign key (ID_CARGO)
      references CARGO (ID_CARGO)
      on update restrict
      on delete restrict;

alter table EMPRESA
   add constraint FK_EMPRESA_ESTA_COMUNA foreign key (ID_COMUNA)
      references COMUNA (ID_COMUNA)
      on update restrict
      on delete restrict;

alter table REGION
   add constraint FK_REGION_PERTENECE_PAIS foreign key (ID_PAIS)
      references PAIS (ID_PAIS)
      on update restrict
      on delete restrict;

alter table RESERVA
   add constraint FK_RESERVA_INTEGRA2_TIEMPO_A foreign key (ID_ATENCION)
      references TIEMPO_ATENCION (ID_ATENCION)
      on update restrict
      on delete restrict;

alter table RESERVA
   add constraint FK_RESERVA_PERTENECE_CLIENTE foreign key (ID_CLIENTE)
      references CLIENTE (ID_CLIENTE)
      on update restrict
      on delete restrict;

alter table RESERVA
   add constraint FK_RESERVA_POSEE_SUCURSAL foreign key (ID_SUCURSAL)
      references SUCURSAL (ID_SUCURSAL)
      on update restrict
      on delete restrict;

alter table ROL
   add constraint FK_ROL_INTEGRA_PRIVILEG foreign key (ID_PRIVILEGIO)
      references PRIVILEGIO (ID_PRIVILEGIO)
      on update restrict
      on delete restrict;

alter table SUCURSAL
   add constraint FK_SUCURSAL_TIENE_CLASIFIC foreign key (ID_CLASIFICACION)
      references CLASIFICACION (ID_CLASIFICACION)
      on update restrict
      on delete restrict;

alter table SUCURSAL
   add constraint FK_SUCURSAL_TIENE4_EMPRESA foreign key (ID_EMPRESA)
      references EMPRESA (ID_EMPRESA)
      on update restrict
      on delete restrict;

