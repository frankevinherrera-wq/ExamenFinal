using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamenGrupal.Migrations
{
    /// <inheritdoc />
    public partial class DBDatos : Migration
    {
        // Npgsql exige DateTimeKind.Utc para columnas "timestamp with time zone"
        private static DateTime D(int y, int m, int d, int h = 0, int mi = 0, int s = 0)
            => new DateTime(y, m, d, h, mi, s, DateTimeKind.Utc);

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var c = D(2026, 10, 1);

            // ===================== OFICIALES =====================
            migrationBuilder.InsertData(
                table: "Oficiales",
                columns: new[] { "Id", "Nombres", "Apellidos", "Grado", "NumeroEscalafon", "Cargo", "Unidad", "Activo", "CreatedAt" },
                values: new object[,]
                {
                    { 1, "Carlos", "Mamani Quispe", "Capitán", "ESC-001", "Investigador", "Tránsito Tarija", true, c },
                    { 2, "Rodrigo", "Vargas Flores", "Teniente", "ESC-002", "Investigador", "Tránsito Tarija", true, c },
                    { 3, "Luis", "Cruz Gutiérrez", "Sargento Primero", "ESC-003", "Investigador", "Tránsito Tarija", true, c },
                    { 4, "María", "Choque Rojas", "Mayor", "ESC-004", "Perito", "Peritaje Vial", true, c },
                    { 5, "Jorge", "Arce Villca", "Capitán", "ESC-005", "Perito", "Peritaje Vial", true, c }
                });

            // ===================== ACCIDENTES =====================
            migrationBuilder.InsertData(
                table: "Accidentes",
                columns: new[] { "Id", "CodigoCaso", "FechaHora", "TipoAccidente", "Gravedad", "Distrito", "ZonaBarrio",
                    "DireccionReferencia", "Latitud", "Longitud", "CondicionClimatica", "EstadoCalzada", "EstadoCaso",
                    "JuzgadoOInstitucion", "NumeroCuadernoInvestigacion", "MotivoPase", "Observaciones", "CreatedAt", "OficialAsignadoId" },
                values: new object[,]
                {
                    { 1, "ACC-2026-001", D(2026,8,3,7,45,0), "Colisión", "Leve", "Distrito 1", "Centro", "Av. La Paz esq. Bolívar", -21.5355m, -64.7296m, "Despejado", "Seco", "En investigación", "Juzgado 1ro de Tránsito", "CUD-001", null, "Daños materiales menores", c, 1 },
                    { 2, "ACC-2026-002", D(2026,8,5,22,10,0), "Atropello", "Grave", "Distrito 2", "San Roque", "Av. Las Américas y Calle Ingavi", -21.5290m, -64.7350m, "Nublado", "Húmedo", "Remitido a Fiscalía", "Fiscalía de Tarija", "CUD-002", "Lesiones graves", "Peatón cruzó fuera de paso cebra", c, 2 },
                    { 3, "ACC-2026-003", D(2026,8,9,14,30,0), "Choque", "Leve", "Distrito 3", "Lourdes", "Av. Panamericana km 2", -21.5480m, -64.7210m, "Despejado", "Seco", "Cerrado", "Juzgado 2do de Tránsito", "CUD-003", null, "Acuerdo entre partes", c, 3 },
                    { 4, "ACC-2026-004", D(2026,8,12,1,20,0), "Vuelco", "Grave", "Distrito 5", "Villa Fátima", "Carretera a San Lorenzo", -21.4900m, -64.7600m, "Lluvia", "Mojado", "En investigación", "Fiscalía de Tarija", "CUD-004", "Lesiones graves", "Posible exceso de velocidad", c, 1 },
                    { 5, "ACC-2026-005", D(2026,8,15,18,5,0), "Colisión", "Moderado", "Distrito 1", "Centro", "Calle Sucre y Colón", -21.5340m, -64.7280m, "Despejado", "Seco", "En investigación", "Juzgado 1ro de Tránsito", "CUD-005", null, null, c, 2 },
                    { 6, "ACC-2026-006", D(2026,8,18,6,50,0), "Atropello", "Fatal", "Distrito 4", "Aranjuez", "Av. Circunvalación", -21.5600m, -64.7100m, "Neblina", "Seco", "Remitido a Fiscalía", "Fiscalía de Tarija", "CUD-006", "Fallecimiento", "Víctima ciclista", c, 3 },
                    { 7, "ACC-2026-007", D(2026,8,22,13,15,0), "Choque", "Leve", "Distrito 2", "El Molino", "Av. Jaime Paz y Calle Ballivián", -21.5270m, -64.7410m, "Despejado", "Seco", "Cerrado", "Juzgado 2do de Tránsito", "CUD-007", null, "Conciliación", c, 1 },
                    { 8, "ACC-2026-008", D(2026,8,26,23,40,0), "Colisión", "Grave", "Distrito 3", "Morros Blancos", "Av. Panamericana y Calle 3", -21.5510m, -64.7190m, "Despejado", "Seco", "En investigación", "Fiscalía de Tarija", "CUD-008", "Conductor ebrio", "Alcoholemia positiva", c, 2 },
                    { 9, "ACC-2026-009", D(2026,8,30,9,25,0), "Choque", "Moderado", "Distrito 1", "Centro", "Calle Domingo Paz", -21.5360m, -64.7310m, "Nublado", "Húmedo", "En investigación", "Juzgado 1ro de Tránsito", "CUD-009", null, null, c, 3 },
                    { 10, "ACC-2026-010", D(2026,9,2,16,0,0), "Atropello", "Moderado", "Distrito 5", "Juan XXIII", "Av. Víctor Paz", -21.5050m, -64.7550m, "Despejado", "Seco", "En investigación", "Fiscalía de Tarija", "CUD-010", null, "Conductor se dio a la fuga y fue ubicado", c, 1 },
                    { 11, "ACC-2026-011", D(2026,9,5,20,35,0), "Colisión", "Leve", "Distrito 2", "San Roque", "Calle Campero", -21.5300m, -64.7330m, "Despejado", "Seco", "Cerrado", "Juzgado 2do de Tránsito", "CUD-011", null, null, c, 2 },
                    { 12, "ACC-2026-012", D(2026,9,8,3,10,0), "Vuelco", "Fatal", "Distrito 6", "Tomatitas", "Carretera a Tomatitas", -21.5800m, -64.7000m, "Lluvia", "Mojado", "Remitido a Fiscalía", "Fiscalía de Tarija", "CUD-012", "Fallecimiento", "Curva peligrosa", c, 3 },
                    { 13, "ACC-2026-013", D(2026,9,11,12,45,0), "Choque", "Leve", "Distrito 1", "Centro", "Plaza Luis de Fuentes", -21.5345m, -64.7290m, "Despejado", "Seco", "Cerrado", "Juzgado 1ro de Tránsito", "CUD-013", null, null, c, 1 },
                    { 14, "ACC-2026-014", D(2026,9,14,19,20,0), "Colisión", "Moderado", "Distrito 3", "Lourdes", "Av. Panamericana y Av. Integración", -21.5470m, -64.7220m, "Nublado", "Seco", "En investigación", "Juzgado 2do de Tránsito", "CUD-014", null, "Falta de distancia de seguridad", c, 2 },
                    { 15, "ACC-2026-015", D(2026,9,17,7,30,0), "Atropello", "Grave", "Distrito 4", "Aranjuez", "Calle Los Pinos", -21.5590m, -64.7120m, "Despejado", "Seco", "Remitido a Fiscalía", "Fiscalía de Tarija", "CUD-015", "Lesiones graves", "Escolar atropellado", c, 3 },
                    { 16, "ACC-2026-016", D(2026,9,20,21,55,0), "Choque", "Leve", "Distrito 2", "El Molino", "Av. Las Américas", -21.5280m, -64.7370m, "Despejado", "Seco", "Cerrado", "Juzgado 1ro de Tránsito", "CUD-016", null, null, c, 1 },
                    { 17, "ACC-2026-017", D(2026,9,24,5,15,0), "Colisión", "Grave", "Distrito 5", "Villa Fátima", "Av. Panamericana km 5", -21.4950m, -64.7580m, "Neblina", "Húmedo", "En investigación", "Fiscalía de Tarija", "CUD-017", "Lesiones graves", "Poca visibilidad", c, 2 },
                    { 18, "ACC-2026-018", D(2026,9,28,15,40,0), "Choque", "Moderado", "Distrito 1", "Centro", "Calle Bolívar y Ingavi", -21.5350m, -64.7300m, "Despejado", "Seco", "En investigación", "Juzgado 2do de Tránsito", "CUD-018", null, null, c, 3 },
                    { 19, "ACC-2026-019", D(2026,10,3,0,30,0), "Vuelco", "Moderado", "Distrito 6", "San Andrés", "Carretera a San Andrés", -21.5700m, -64.6900m, "Despejado", "Seco", "En investigación", "Fiscalía de Tarija", "CUD-019", null, "Conductor en estado de ebriedad", c, 1 },
                    { 20, "ACC-2026-020", D(2026,10,6,17,10,0), "Colisión", "Leve", "Distrito 3", "Morros Blancos", "Av. Circunvalación y Calle 5", -21.5520m, -64.7170m, "Nublado", "Húmedo", "Abierto", "Juzgado 1ro de Tránsito", "CUD-020", null, null, c, 2 }
                });

            // ===================== VEHÍCULOS =====================
            migrationBuilder.InsertData(
                table: "VehiculosInvolucrados",
                columns: new[] { "Id", "Placa", "Marca", "Modelo", "TipoVehiculo", "Color", "NumeroChasis",
                    "SoatVigente", "Aseguradora", "DescripcionDanios", "RemolcadoA", "CreatedAt", "AccidenteId" },
                values: new object[,]
                {
                    { 1, "1234-ABC", "Toyota", "Corolla", "Automóvil", "Blanco", "CH-0001", true, "Alianza Seguros", "Parachoques delantero", null, c, 1 },
                    { 2, "2345-BCD", "Suzuki", "Vitara", "Vagoneta", "Rojo", "CH-0002", true, "Nacional Seguros", "Capó y parabrisas", "Depósito Tránsito", c, 2 },
                    { 3, "3456-CDE", "Nissan", "Sentra", "Automóvil", "Gris", "CH-0003", false, null, "Puerta lateral", null, c, 3 },
                    { 4, "4567-DEF", "Toyota", "Hilux", "Camioneta", "Negro", "CH-0004", true, "Alianza Seguros", "Daños totales", "Depósito Tránsito", c, 4 },
                    { 5, "5678-EFG", "Hyundai", "Accent", "Automóvil", "Azul", "CH-0005", true, "Bisa Seguros", "Faro y guardabarros", null, c, 5 },
                    { 6, "6789-FGH", "Honda", "CB125", "Motocicleta", "Negro", "CH-0006", false, null, "Manubrio y tanque", "Depósito Tránsito", c, 6 },
                    { 7, "7890-GHI", "Chevrolet", "Spark", "Automóvil", "Plomo", "CH-0007", true, "Nacional Seguros", "Parachoques trasero", null, c, 7 },
                    { 8, "8901-HIJ", "Toyota", "Yaris", "Automóvil", "Verde", "CH-0008", true, "Alianza Seguros", "Frontal destruido", "Depósito Tránsito", c, 8 },
                    { 9, "9012-IJK", "Kia", "Rio", "Automóvil", "Blanco", "CH-0009", true, "Bisa Seguros", "Espejo y puerta", null, c, 9 },
                    { 10, "1122-JKL", "Mitsubishi", "L200", "Camioneta", "Dorado", "CH-0010", false, null, "Sin daños visibles", null, c, 10 },
                    { 11, "2233-KLM", "Suzuki", "Swift", "Automóvil", "Rojo", "CH-0011", true, "Nacional Seguros", "Parachoques", null, c, 11 },
                    { 12, "3344-LMN", "Toyota", "Land Cruiser", "Vagoneta", "Blanco", "CH-0012", true, "Alianza Seguros", "Daños totales", "Depósito Tránsito", c, 12 },
                    { 13, "4455-MNO", "Nissan", "Versa", "Automóvil", "Negro", "CH-0013", true, "Bisa Seguros", "Rayones laterales", null, c, 13 },
                    { 14, "5566-NOP", "Volkswagen", "Gol", "Automóvil", "Azul", "CH-0014", false, null, "Parte trasera", null, c, 14 },
                    { 15, "6677-OPQ", "Yamaha", "YBR125", "Motocicleta", "Rojo", "CH-0015", false, null, "Rueda delantera", "Depósito Tránsito", c, 15 },
                    { 16, "7788-PQR", "Toyota", "RAV4", "Vagoneta", "Plomo", "CH-0016", true, "Nacional Seguros", "Parachoques", null, c, 16 },
                    { 17, "8899-QRS", "Hyundai", "Tucson", "Vagoneta", "Blanco", "CH-0017", true, "Alianza Seguros", "Frontal y capó", "Depósito Tránsito", c, 17 },
                    { 18, "9900-RST", "Chevrolet", "Sail", "Automóvil", "Plata", "CH-0018", true, "Bisa Seguros", "Puerta trasera", null, c, 18 },
                    { 19, "1357-STU", "Toyota", "Hilux", "Camioneta", "Blanco", "CH-0019", false, null, "Vuelco, daños en techo", "Depósito Tránsito", c, 19 },
                    { 20, "2468-TUV", "Suzuki", "Alto", "Automóvil", "Amarillo", "CH-0020", true, "Nacional Seguros", "Parachoques delantero", null, c, 20 }
                });

            // ===================== PERSONAS =====================
            migrationBuilder.InsertData(
                table: "PersonasInvolucradas",
                columns: new[] { "Id", "Nombres", "Apellidos", "Ci", "Telefono", "Rol", "NumeroLicencia", "CategoriaLicencia",
                    "GradoAlcoholemiaGral", "EstadoAlcoholemia", "NumeroActaDosaje", "Laboratorio", "EstadoSalud",
                    "CentroMedicoTraslado", "DiagnosticoPreliminar", "CreatedAt", "AccidenteId", "VehiculoId" },
                values: new object[,]
                {
                    { 1, "Juan", "Pérez Lima", "5123456", "70011111", "Conductor", "LIC-1001", "B", 0.0m, "Negativo", null, null, "Ileso", null, null, c, 1, 1 },
                    { 2, "Ana", "Torrez Soria", "5234567", "70022222", "Peatón", null, null, null, null, null, null, "Herido grave", "Hospital San Juan de Dios", "Politraumatismo", c, 2, 2 },
                    { 3, "Pedro", "Gómez Ruiz", "5345678", "70033333", "Conductor", "LIC-1003", "B", 0.0m, "Negativo", null, null, "Ileso", null, null, c, 3, 3 },
                    { 4, "Marcos", "Salazar Peña", "5456789", "70044444", "Conductor", "LIC-1004", "C", 0.8m, "Positivo", "DOS-0004", "Lab. Policial", "Herido grave", "Hospital Obrero", "Fractura de pelvis", c, 4, 4 },
                    { 5, "Lucía", "Fernández Ortiz", "5567890", "70055555", "Conductor", "LIC-1005", "B", 0.0m, "Negativo", null, null, "Herido leve", "Clínica Tarija", "Contusiones", c, 5, 5 },
                    { 6, "Rubén", "Medina Cori", "5678901", "70066666", "Ciclista", null, null, null, null, null, null, "Fallecido", "Hospital San Juan de Dios", "Traumatismo craneoencefálico", c, 6, 6 },
                    { 7, "Sandra", "Aguilar Vaca", "5789012", "70077777", "Conductor", "LIC-1007", "B", 0.0m, "Negativo", null, null, "Ileso", null, null, c, 7, 7 },
                    { 8, "Hugo", "Barrientos Díaz", "5890123", "70088888", "Conductor", "LIC-1008", "B", 1.5m, "Positivo", "DOS-0008", "Lab. Policial", "Herido leve", "Clínica Tarija", "Contusión torácica", c, 8, 8 },
                    { 9, "Gabriela", "Rojas Mamani", "5901234", "70099999", "Conductor", "LIC-1009", "A", 0.0m, "Negativo", null, null, "Ileso", null, null, c, 9, 9 },
                    { 10, "Víctor", "Choque Arias", "6012345", "70101010", "Conductor", "LIC-1010", "C", 0.0m, "Negativo", null, null, "Ileso", null, null, c, 10, 10 },
                    { 11, "Daniela", "Ramos Cruz", "6123456", "70111212", "Conductor", "LIC-1011", "B", 0.0m, "Negativo", null, null, "Ileso", null, null, c, 11, 11 },
                    { 12, "Fernando", "Quiroga Paz", "6234567", "70121313", "Conductor", "LIC-1012", "C", 0.3m, "Positivo", "DOS-0012", "Lab. Policial", "Fallecido", "Hospital San Juan de Dios", "Trauma múltiple", c, 12, 12 },
                    { 13, "Elena", "Villarroel Sosa", "6345678", "70131414", "Conductor", "LIC-1013", "B", 0.0m, "Negativo", null, null, "Ileso", null, null, c, 13, 13 },
                    { 14, "Oscar", "Lazcano Mora", "6456789", "70141515", "Conductor", "LIC-1014", "B", 0.0m, "Negativo", null, null, "Herido leve", "Clínica Tarija", "Latigazo cervical", c, 14, 14 },
                    { 15, "Kevin", "Flores Tapia", "6567890", "70151616", "Peatón", null, null, null, null, null, null, "Herido grave", "Hospital Obrero", "Fractura de fémur", c, 15, 15 },
                    { 16, "Patricia", "Núñez Vega", "6678901", "70161717", "Conductor", "LIC-1016", "B", 0.0m, "Negativo", null, null, "Ileso", null, null, c, 16, 16 },
                    { 17, "Álvaro", "Guzmán Leaño", "6789012", "70171818", "Conductor", "LIC-1017", "B", 0.0m, "Negativo", null, null, "Herido grave", "Hospital San Juan de Dios", "Trauma de columna", c, 17, 17 },
                    { 18, "Rosa", "Condori Alanoca", "6890123", "70181919", "Conductor", "LIC-1018", "B", 0.0m, "Negativo", null, null, "Ileso", null, null, c, 18, 18 },
                    { 19, "Mauricio", "Espinoza Gallo", "6901234", "70192020", "Conductor", "LIC-1019", "C", 1.2m, "Positivo", "DOS-0019", "Lab. Policial", "Herido leve", "Clínica Tarija", "Heridas cortantes", c, 19, 19 },
                    { 20, "Silvia", "Montaño Rivera", "7012345", "70202121", "Conductor", "LIC-1020", "B", 0.0m, "Negativo", null, null, "Ileso", null, null, c, 20, 20 }
                });

            // ===================== PERITAJES (accidentes 1 al 10) =====================
            migrationBuilder.InsertData(
                table: "PeritajesTecnicos",
                columns: new[] { "Id", "FechaPeritaje", "VelocidadEstimadaImpactoKmh", "HuellaFrenadoMetros",
                    "FactorDeterminante", "Conclusiones", "CroquisUrl", "CreatedAt", "AccidenteId", "PeritoId" },
                values: new object[,]
                {
                    { 1, D(2026,8,5), 35.0m, 6.5m, "Falta de atención", "Colisión por distracción del conductor", "https://croquis.example.com/1.png", c, 1, 4 },
                    { 2, D(2026,8,7), 55.0m, 12.0m, "Imprudencia del peatón", "Peatón cruzó fuera del paso cebra", "https://croquis.example.com/2.png", c, 2, 5 },
                    { 3, D(2026,8,11), 30.0m, 4.0m, "No respetó señal de pare", "Vehículo no cedió el paso", null, c, 3, 4 },
                    { 4, D(2026,8,14), 95.0m, 25.0m, "Exceso de velocidad", "Pérdida de control en curva con calzada mojada", "https://croquis.example.com/4.png", c, 4, 5 },
                    { 5, D(2026,8,17), 40.0m, 8.0m, "Distancia de seguridad", "No guardó distancia de seguridad", null, c, 5, 4 },
                    { 6, D(2026,8,20), 70.0m, 15.5m, "Exceso de velocidad", "Velocidad inadecuada con neblina", "https://croquis.example.com/6.png", c, 6, 5 },
                    { 7, D(2026,8,24), 25.0m, 3.0m, "Maniobra indebida", "Cambio de carril sin señalizar", null, c, 7, 4 },
                    { 8, D(2026,8,28), 85.0m, 20.0m, "Estado de ebriedad", "Conductor ebrio invadió carril contrario", "https://croquis.example.com/8.png", c, 8, 5 },
                    { 9, D(2026,9,1), 32.0m, 5.5m, "Falta de atención", "Choque por uso del celular", null, c, 9, 4 },
                    { 10, D(2026,9,4), 60.0m, null, "Imprudencia del conductor", "Conductor no respetó paso peatonal y se dio a la fuga", "https://croquis.example.com/10.png", c, 10, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Se eliminan en orden inverso por las llaves foráneas
            migrationBuilder.DeleteData("PeritajesTecnicos", "Id",
                Enumerable.Range(1, 10).Select(i => (object)i).ToArray());

            migrationBuilder.DeleteData("PersonasInvolucradas", "Id",
                Enumerable.Range(1, 20).Select(i => (object)i).ToArray());

            migrationBuilder.DeleteData("VehiculosInvolucrados", "Id",
                Enumerable.Range(1, 20).Select(i => (object)i).ToArray());

            migrationBuilder.DeleteData("Accidentes", "Id",
                Enumerable.Range(1, 20).Select(i => (object)i).ToArray());

            migrationBuilder.DeleteData("Oficiales", "Id",
                Enumerable.Range(1, 5).Select(i => (object)i).ToArray());
        }
    }
}