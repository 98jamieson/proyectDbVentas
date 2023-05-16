

/*PROCEDURE 1*/
create or replace NONEDITIONABLE PROCEDURE pr_get_Clientes(
C_CURSOR OUT SYS_REFCURSOR
)
AS

BEGIN
    OPEN C_CURSOR FOR
    SELECT *FROM APL_CLIENTE WHERE CLI_ESTADO=1;
END;

/*PROCEDURE 2*/
create or replace NONEDITIONABLE PROCEDURE pr_get_Cliente(
C_CURSOR OUT SYS_REFCURSOR,
v_cli_numero_documento IN APL_CLIENTE.CLI_NUMERO_DOCUMENTO%TYPE DEFAULT NULL
)
AS

BEGIN
    OPEN C_CURSOR FOR
    SELECT *FROM APL_CLIENTE WHERE cli_numero_documento=v_cli_numero_documento;
END;

/*PROCEDURE 3***/
create or replace NONEDITIONABLE PROCEDURE PR_SET_CLIENTE(
  p_CLI_ID IN APL_CLIENTE.CLI_IDCLIENTE%TYPE   DEFAULT NULL,  
  p_CLI_NOMBRE1 IN APL_CLIENTE.CLI_NOMBRE1%TYPE DEFAULT NULL,
  p_CLI_NOMBRE2 IN APL_CLIENTE.CLI_NOMBRE2%TYPE DEFAULT NULL,
  p_CLI_OTROSNOMBRES IN APL_CLIENTE.CLI_OTROSNOMBRES%TYPE DEFAULT NULL,
  p_CLI_APELLIDO1 IN APL_CLIENTE.CLI_APELLIDO1%TYPE DEFAULT NULL,
  p_CLI_APELLIDO2 IN APL_CLIENTE.CLI_APELLIDO2%TYPE DEFAULT NULL,
  p_CLI_APELLIDOCASADA IN APL_CLIENTE.CLI_APELLIDOCASADA%TYPE DEFAULT NULL,
  p_CLI_ESTADO IN APL_CLIENTE.CLI_ESTADO%TYPE DEFAULT NULL,
  p_CLI_PROFESION IN APL_CLIENTE.CLI_PROFESION%TYPE DEFAULT NULL,
  p_CLI_TIPO_PERSONA IN APL_CLIENTE.CLI_TIPO_PERSONA%TYPE DEFAULT NULL,
  p_CLI_NIT IN APL_CLIENTE.CLI_NIT%TYPE DEFAULT NULL
)
AS
BEGIN
    INSERT INTO APL_CLIENTE(CLI_IDCLIENTE,CLI_NOMBRE1,CLI_NOMBRE2,CLI_OTROSNOMBRES,CLI_APELLIDO1,CLI_APELLIDO2,CLI_APELLIDOCASADA,CLI_ESTADO,CLI_PROFESION,CLI_TIPO_PERSONA,CLI_NIT) 
    VALUES(p_CLI_ID,p_CLI_NOMBRE1,p_CLI_NOMBRE2,p_CLI_OTROSNOMBRES,p_CLI_APELLIDO1,p_CLI_APELLIDO2,p_CLI_APELLIDOCASADA,p_CLI_ESTADO,p_CLI_PROFESION,
    p_CLI_TIPO_PERSONA,p_CLI_NIT);
END;

/* PROCEDURE 4 DELETE */

create or replace NONEDITIONABLE PROCEDURE PR_DELETE_CLIENTE
(
  p_CLI_NUMERO_DOCUMENTO IN APL_CLIENTE.CLI_NUMERO_DOCUMENTO%TYPE,
  p_CLI_ESTADO IN APL_CLIENTE.CLI_ESTADO%TYPE DEFAULT NULL
)
AS
BEGIN
    UPDATE APL_CLIENTE SET 
    CLI_ESTADO=NVL(p_CLI_ESTADO,CLI_ESTADO)
    WHERE CLI_NUMERO_DOCUMENTO = p_CLI_NUMERO_DOCUMENTO;
    COMMIT;
END;



/*PROCEDURE 5 UPDATE */
create or replace NONEDITIONABLE PROCEDURE PR_UPDATE_CLIENTES
(
  p_CLI_NUMERO_DOCUMENTO IN APL_CLIENTE.CLI_NUMERO_DOCUMENTO%TYPE,
  p_CLI_ID IN APL_CLIENTE.CLI_IDCLIENTE%TYPE   DEFAULT NULL,  
  p_CLI_NOMBRE1 IN APL_CLIENTE.CLI_NOMBRE1%TYPE DEFAULT NULL,
  p_CLI_NOMBRE2 IN APL_CLIENTE.CLI_NOMBRE2%TYPE DEFAULT NULL,
  p_CLI_OTROSNOMBRES IN APL_CLIENTE.CLI_OTROSNOMBRES%TYPE DEFAULT NULL,
  p_CLI_APELLIDO1 IN APL_CLIENTE.CLI_APELLIDO1%TYPE DEFAULT NULL,
  p_CLI_APELLIDO2 IN APL_CLIENTE.CLI_APELLIDO2%TYPE DEFAULT NULL,
  p_CLI_APELLIDOCASADA IN APL_CLIENTE.CLI_APELLIDOCASADA%TYPE DEFAULT NULL,
  p_CLI_ESTADO IN APL_CLIENTE.CLI_ESTADO%TYPE DEFAULT NULL,
  p_CLI_PROFESION IN APL_CLIENTE.CLI_PROFESION%TYPE DEFAULT NULL,
  p_CLI_TIPO_PERSONA IN APL_CLIENTE.CLI_TIPO_PERSONA%TYPE DEFAULT NULL,
  p_CLI_NIT IN APL_CLIENTE.CLI_NIT%TYPE DEFAULT NULL
)
AS
BEGIN
    UPDATE APL_CLIENTE SET 
    CLI_IDCLIENTE= NVL(p_CLI_ID,CLI_IDCLIENTE),
    CLI_NOMBRE1=NVL(p_CLI_NOMBRE1,CLI_NOMBRE1),
    CLI_NOMBRE2=NVL( p_CLI_NOMBRE2,CLI_NOMBRE2),
    CLI_OTROSNOMBRES= NVL(p_CLI_OTROSNOMBRES,CLI_OTROSNOMBRES),
    CLI_APELLIDO1=NVL(p_CLI_APELLIDO1,CLI_APELLIDO1),
    CLI_APELLIDO2=NVL(p_CLI_APELLIDO2,CLI_APELLIDO2),
    CLI_APELLIDOCASADA=NVL( p_CLI_APELLIDOCASADA,CLI_APELLIDOCASADA),
    CLI_ESTADO=NVL(p_CLI_ESTADO,CLI_ESTADO),
    CLI_TIPO_PERSONA = NVL( p_CLI_TIPO_PERSONA,CLI_TIPO_PERSONA),
    CLI_NIT=NVL(p_CLI_NIT,CLI_NIT)
    WHERE CLI_NUMERO_DOCUMENTO = p_CLI_NUMERO_DOCUMENTO;
    COMMIT;
END;





