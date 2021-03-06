﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BeLife.Negocio.Consultas {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class StringResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal StringResources() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("BeLife.Negocio.Consultas.StringResources", typeof(StringResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a UPDATE cliente SET nombreCliente=:nombreCliente, apellidosCliente=:apellidosCliente, fechaNacimiento=:fechaNacimiento, idSexo=:idSexo, idEstadoCivil=:idEstadoCivil WHERE rutCliente=:rutCliente.
        /// </summary>
        internal static string queryCliente_Actualizar {
            get {
                return ResourceManager.GetString("queryCliente_Actualizar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a DELETE FROM cliente WHERE trim(lower(RutCliente))=trim(lower(:RutCliente)).
        /// </summary>
        internal static string queryCliente_Eliminar {
            get {
                return ResourceManager.GetString("queryCliente_Eliminar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a INSERT INTO cliente VALUES(:rutCliente, :nombreCliente, :apellidosCliente, :fechaNacimiento, :idSexo, :idEstadoCivil).
        /// </summary>
        internal static string queryCliente_Insertar {
            get {
                return ResourceManager.GetString("queryCliente_Insertar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a SELECT C.numero AS Numero, to_char(C.FECHACONTRATO, &apos;dd/MM/yyyy&apos;) AS Inicio_contrato, to_char(C.FECHATERMINOCONTRATO, &apos;dd/MM/yyyy&apos;) AS Termino_contrato, C.idPlan AS idPlan, p.nombre AS Nombre_plan, to_char(FECHAINICIOVIGENCIA, &apos;dd/MM/yyyy&apos;) AS Inicio_vigencia, to_char(C.FECHAFINVIGENCIA, &apos;dd/MM/yyyy&apos;) AS Termino_vigencia, CASE WHEN C.VIGENTE=1 THEN &apos;Si&apos; ELSE &apos;No&apos; END AS Vigente, CASE WHEN C.DECLARACIONSALUD=1 THEN &apos;Si&apos; ELSE &apos;No&apos; END AS Declaracion_salud, p.PRIMABASE as Prima_base, C.PRIMAMENSUAL AS Prima_me [resto de la cadena truncado]&quot;;.
        /// </summary>
        internal static string queryCliente_ListaContratos {
            get {
                return ResourceManager.GetString("queryCliente_ListaContratos", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a SELECT cli.RutCliente AS Rut, cli.nombreCliente AS Nombre, cli.apellidosCliente AS Apellido, cli.fechaNacimiento AS Fecha, est.IdEstadoCivil AS IdEstado, est.descripcion AS EstadoCivil, sex.IdSexo AS IdSexo, sex.descripcion AS Sexo FROM cliente cli join estadoCivil est on cli.IdEstadoCivil=est.IdEstadoCivil join sexo sex on cli.IdSexo=sex.IdSexo WHERE est.IdEstadoCivil=:idEstadoCivil ORDER BY cli.apellidosCliente, cli.NombreCliente.
        /// </summary>
        internal static string queryCliente_ListarPorEstadoCivil {
            get {
                return ResourceManager.GetString("queryCliente_ListarPorEstadoCivil", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a SELECT cli.RutCliente AS Rut, cli.nombreCliente AS Nombre, cli.apellidosCliente AS Apellido, cli.fechaNacimiento AS Fecha, est.IdEstadoCivil AS IdEstado, est.descripcion AS EstadoCivil, sex.IdSexo AS IdSexo, sex.descripcion AS Sexo FROM cliente cli join estadoCivil est on cli.IdEstadoCivil=est.IdEstadoCivil join sexo sex on cli.IdSexo=sex.IdSexo WHERE trim(lower(cli.RutCliente))=trim(lower(:RutCliente)) ORDER BY cli.apellidosCliente, cli.NombreCliente.
        /// </summary>
        internal static string queryCliente_ListarPorRut {
            get {
                return ResourceManager.GetString("queryCliente_ListarPorRut", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a SELECT cli.RutCliente AS Rut, cli.nombreCliente AS Nombre, cli.apellidosCliente AS Apellido, cli.fechaNacimiento AS Fecha, est.IdEstadoCivil AS IdEstado, est.descripcion AS EstadoCivil, sex.IdSexo AS IdSexo, sex.descripcion AS Sexo FROM cliente cli join estadoCivil est on cli.IdEstadoCivil=est.IdEstadoCivil join sexo sex on cli.IdSexo=sex.IdSexo WHERE sex.IdSexo=:idSexo ORDER BY cli.apellidosCliente, cli.NombreCliente .
        /// </summary>
        internal static string queryCliente_ListarPorSexo {
            get {
                return ResourceManager.GetString("queryCliente_ListarPorSexo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a SELECT cli.RutCliente AS Rut, cli.nombreCliente AS Nombre, cli.apellidosCliente AS Apellido, cli.fechaNacimiento AS Fecha, est.IdEstadoCivil AS IdEstado, est.descripcion AS EstadoCivil, sex.IdSexo AS IdSexo, sex.descripcion AS Sexo FROM cliente cli join estadoCivil est on cli.IdEstadoCivil=est.IdEstadoCivil join sexo sex on cli.IdSexo=sex.IdSexo ORDER BY cli.apellidosCliente, cli.NombreCliente.
        /// </summary>
        internal static string queryCliente_ListarTodo {
            get {
                return ResourceManager.GetString("queryCliente_ListarTodo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a SELECT co.idComuna, co.nombreComuna FROM region_comuna rc JOIN comuna co ON rc.idComuna=co.idComuna WHERE rc.idRegion=:pIdRegion ORDER BY co.idComuna.
        /// </summary>
        internal static string queryComuna_ListarPorRegion {
            get {
                return ResourceManager.GetString("queryComuna_ListarPorRegion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a UPDATE  contrato SET fechaContrato=:fechaInicioContrato, fechaTerminoContrato=:fechaTerminoContrato, idPlan=:idPlan, fechaInicioVigencia=:inicioVigencia, fechaFinVigencia=:terminoVigencia, vigente=:vigente, declaracionSalud=:salud, primaAnual=:primaAnual, primaMensual=:primaMensual, observaciones=:observaciones WHERE numero=:numero AND rutCliente=:rutCliente.
        /// </summary>
        internal static string queryContrato_Actualizar {
            get {
                return ResourceManager.GetString("queryContrato_Actualizar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a INSERT INTO contrato VALUES (:numero, :fechaInicioContrato, :fechaTerminoContrato,  :rutCliente, :idPlan, :inicioVigencia, :terminoVigencia, :vigente, :salud, :primaAnual, :primaMensual, :observaciones).
        /// </summary>
        internal static string queryContrato_Insertar {
            get {
                return ResourceManager.GetString("queryContrato_Insertar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a SELECT C.numero AS Numero, to_char(C.FECHACONTRATO, &apos;dd/MM/yyyy&apos;) AS Inicio_contrato, to_char(C.FECHATERMINOCONTRATO, &apos;dd/MM/yyyy&apos;) AS Termino_contrato, c.rutCliente as Rut, cl.nombreCliente||&apos; &apos;||cl.apellidosCliente  as Cliente,tpc.idtipocontrato as IdTipoContrato, tpc.descripcion as TipoContrato, C.idPlan AS idPlan, p.nombre AS Nombre_plan, p.polizaActual AS Poliza, to_char(FECHAINICIOVIGENCIA, &apos;dd/MM/yyyy&apos;) AS Inicio_vigencia, to_char(C.FECHAFINVIGENCIA, &apos;dd/MM/yyyy&apos;) AS Termino_vigencia, CASE WHEN C.VIG [resto de la cadena truncado]&quot;;.
        /// </summary>
        internal static string queryContrato_ListarPorNumeroContrato {
            get {
                return ResourceManager.GetString("queryContrato_ListarPorNumeroContrato", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a SELECT C.numero AS Numero, to_char(C.FECHACONTRATO, &apos;dd/MM/yyyy&apos;) AS Inicio_contrato, to_char(C.FECHATERMINOCONTRATO, &apos;dd/MM/yyyy&apos;) AS Termino_contrato, c.rutCliente as Rut, cl.nombreCliente||&apos; &apos;||cl.apellidosCliente  as Cliente,tpc.idtipocontrato as IdTipoContrato, tpc.descripcion as TipoContrato, C.idPlan AS idPlan, p.nombre AS Nombre_plan, p.polizaActual AS Poliza, to_char(FECHAINICIOVIGENCIA, &apos;dd/MM/yyyy&apos;) AS Inicio_vigencia, to_char(C.FECHAFINVIGENCIA, &apos;dd/MM/yyyy&apos;) AS Termino_vigencia, CASE WHEN C.VIG [resto de la cadena truncado]&quot;;.
        /// </summary>
        internal static string queryContrato_ListarPorNumeroDePoliza {
            get {
                return ResourceManager.GetString("queryContrato_ListarPorNumeroDePoliza", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a SELECT C.numero AS Numero, to_char(C.FECHACONTRATO, &apos;dd/MM/yyyy&apos;) AS Inicio_contrato, to_char(C.FECHATERMINOCONTRATO, &apos;dd/MM/yyyy&apos;) AS Termino_contrato, c.rutCliente as Rut, cl.nombreCliente||&apos; &apos;||cl.apellidosCliente  as Cliente,tpc.idtipocontrato as IdTipoContrato, tpc.descripcion as TipoContrato, C.idPlan AS idPlan, p.nombre AS Nombre_plan, p.polizaActual AS Poliza, to_char(FECHAINICIOVIGENCIA, &apos;dd/MM/yyyy&apos;) AS Inicio_vigencia, to_char(C.FECHAFINVIGENCIA, &apos;dd/MM/yyyy&apos;) AS Termino_vigencia, CASE WHEN C.VIG [resto de la cadena truncado]&quot;;.
        /// </summary>
        internal static string queryContrato_ListarPorRut {
            get {
                return ResourceManager.GetString("queryContrato_ListarPorRut", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a SELECT C.numero AS Numero, to_char(C.FECHACONTRATO, &apos;dd/MM/yyyy&apos;) AS Inicio_contrato, to_char(C.FECHATERMINOCONTRATO, &apos;dd/MM/yyyy&apos;) AS Termino_contrato, c.rutCliente as Rut, cl.nombreCliente||&apos; &apos;||cl.apellidosCliente  as Cliente,tpc.idtipocontrato as IdTipoContrato, tpc.descripcion as TipoContrato, C.idPlan AS idPlan, p.nombre AS Nombre_plan, p.polizaActual AS Poliza, to_char(FECHAINICIOVIGENCIA, &apos;dd/MM/yyyy&apos;) AS Inicio_vigencia, to_char(C.FECHAFINVIGENCIA, &apos;dd/MM/yyyy&apos;) AS Termino_vigencia, CASE WHEN C.VIG [resto de la cadena truncado]&quot;;.
        /// </summary>
        internal static string queryContrato_ListarTodo {
            get {
                return ResourceManager.GetString("queryContrato_ListarTodo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a SELECT C.numero AS Numero, to_char(C.FECHACONTRATO, &apos;dd/MM/yyyy&apos;) AS Inicio_contrato, to_char(C.FECHATERMINOCONTRATO, &apos;dd/MM/yyyy&apos;) AS Termino_contrato, c.rutCliente as Rut, cl.nombreCliente||&apos; &apos;||cl.apellidosCliente  as Cliente, C.idPlan AS idPlan, p.nombre AS Nombre_plan, p.polizaActual AS Poliza, to_char(FECHAINICIOVIGENCIA, &apos;dd/MM/yyyy&apos;) AS Inicio_vigencia, to_char(C.FECHAFINVIGENCIA, &apos;dd/MM/yyyy&apos;) AS Termino_vigencia, CASE WHEN C.VIGENTE=1 THEN &apos;Si&apos; ELSE &apos;No&apos; END AS Vigente, CASE WHEN C.DECLARACIONSALU [resto de la cadena truncado]&quot;;.
        /// </summary>
        internal static string queryContrato_VerificarVigenciaDeContrato {
            get {
                return ResourceManager.GetString("queryContrato_VerificarVigenciaDeContrato", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a SELECT * FROM estadocivil ORDER BY idEstadoCivil.
        /// </summary>
        internal static string queryEstadoCivil_ListarTodo {
            get {
                return ResourceManager.GetString("queryEstadoCivil_ListarTodo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a SELECT * FROM plan WHERE idTipoContrato=:idTipo ORDER BY idPlan.
        /// </summary>
        internal static string queryPlan_ListarPorTipoPlan {
            get {
                return ResourceManager.GetString("queryPlan_ListarPorTipoPlan", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a SELECT * FROM tipo_contrato ORDER BY idTipoContrato.
        /// </summary>
        internal static string queryPlan_ListarTiposDePlan {
            get {
                return ResourceManager.GetString("queryPlan_ListarTiposDePlan", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a SELECT * FROM plan ORDER BY idPlan.
        /// </summary>
        internal static string queryPlan_ListarTodo {
            get {
                return ResourceManager.GetString("queryPlan_ListarTodo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a select * from region order by idRegion.
        /// </summary>
        internal static string queryRegion_ListarTodo {
            get {
                return ResourceManager.GetString("queryRegion_ListarTodo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a SELECT * FROM sexo ORDER BY idSexo.
        /// </summary>
        internal static string querySexo_ListarTodo {
            get {
                return ResourceManager.GetString("querySexo_ListarTodo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a SELECT veh.patente as Patente, mav.idmarca as IdMarca, mav.descripcion as Marca, mov.idmodelo as IdModelo, mov.descripcion as Modelo, veh.anho as AnoVehiculo FROM vehiculo veh JOIN modelo_vehiculo mov ON veh.idmodelo=mov.idmodelo JOIN marcamodelo_vehiculo mmv ON mov.idmodelo=mmv.idmodelo join marca_vehiculo mav on mmv.idmarca=mav.idmarca JOIN contrato_vehiculo cvh on veh.patente=cvh.patente WHERE cvh.numero=:pNroContrato .
        /// </summary>
        internal static string queryVehiculo_BuscarPorNroContrato {
            get {
                return ResourceManager.GetString("queryVehiculo_BuscarPorNroContrato", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a DELETE FROM vehiculo WHERE patente=:pPatente.
        /// </summary>
        internal static string queryVehiculo_eliminaVehiculo {
            get {
                return ResourceManager.GetString("queryVehiculo_eliminaVehiculo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a INSERT INTO vehiculo VALUES(:pPatente, :pIdModelo, :pAno).
        /// </summary>
        internal static string queryVehiculo_Insertar {
            get {
                return ResourceManager.GetString("queryVehiculo_Insertar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a SELECT * FROM marca_vehiculo ORDER BY idMarca .
        /// </summary>
        internal static string queryVehiculo_ListarMarcas {
            get {
                return ResourceManager.GetString("queryVehiculo_ListarMarcas", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a SELECT mo.idmodelo, mo.descripcion FROM marcamodelo_vehiculo mv JOIN modelo_vehiculo mo ON mv.idModelo=mo.idModelo WHERE mv.idMarca=:pIdMarca ORDER BY mo.idModelo.
        /// </summary>
        internal static string queryVehiculo_ListarModelosPorMarca {
            get {
                return ResourceManager.GetString("queryVehiculo_ListarModelosPorMarca", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a DELETE FROM contrato_vehiculo WHERE numero=:pNroContrato AND patente=:pPatente.
        /// </summary>
        internal static string queryVehiculo_QuitarRelacion {
            get {
                return ResourceManager.GetString("queryVehiculo_QuitarRelacion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a INSERT INTO contrato_vehiculo VALUES (:pNroContrato, :pPatente).
        /// </summary>
        internal static string queryVehiculo_RelacionarContratoVehiculo {
            get {
                return ResourceManager.GetString("queryVehiculo_RelacionarContratoVehiculo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a INSERT INTO vivienda VALUES (:pCodigoPostal, :pAno, :pDireccion, :pValorInmueble, :pValorContenido, :pIdComuna).
        /// </summary>
        internal static string queryVivienda_Agregar {
            get {
                return ResourceManager.GetString("queryVivienda_Agregar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a INSERT INTO contrato_vivienda VALUES (:pNroContrato, :pCodigoPostal).
        /// </summary>
        internal static string queryVivienda_AgregarRelacion {
            get {
                return ResourceManager.GetString("queryVivienda_AgregarRelacion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a SELECT viv.codigopostal as CodigoPostal, viv.anho as AnoVivienda, viv.direccion as Direccion, reg.idregion, reg.nombreregion as Region, com.idcomuna as IdComuna, com.nombrecomuna as Comuna, viv.valorInmueble as ValorVivienda, viv.valorContenido as ValorContenido FROM vivienda viv JOIN comuna COM ON viv.idcomuna=COM.idcomuna JOIN region_comuna reco ON COM.idcomuna=reco.idcomuna join region reg on reco.idregion=reg.idregion JOIN contrato_vivienda cvi on viv.codigopostal=cvi.codigopostal where cvi.numero=:pNro [resto de la cadena truncado]&quot;;.
        /// </summary>
        internal static string queryVivienda_BuscarPorNroContrato {
            get {
                return ResourceManager.GetString("queryVivienda_BuscarPorNroContrato", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a DELETE FROM contrato_vivienda WHERE numero=:pNroContrato AND codigopostal=:pCodigoPostal.
        /// </summary>
        internal static string queryVivienda_QuitarRelacion {
            get {
                return ResourceManager.GetString("queryVivienda_QuitarRelacion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a DELETE FROM vivienda WHERE codigoPostal=:pCodigoPostal.
        /// </summary>
        internal static string queryVivienda_QuitarVivienda {
            get {
                return ResourceManager.GetString("queryVivienda_QuitarVivienda", resourceCulture);
            }
        }
    }
}
