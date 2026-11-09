# ACA -- Programación Avanzada

# Sistema de Gestión de Biblioteca

---

## PORTADA

**CUN - Corporación Unificada Nacional de Educación Superior **

**INGENERIA DE  SISTEMAS / 54467**

### ACA -- Programación Avanzada

### Sistema de Gestión de Biblioteca

**Presentado por:**
JHON ALEJANDRO BENAVIDES TIBATA

**Docente:**
VERONICA CASTRO

**Fecha:**
BOGOTA DC / 08/11/2026

---

## CONTRAPORTADA

**Sistema de Gestión de Biblioteca**

Proyecto desarrollado como evidencia del curso de **Programación Avanzada**, aplicando Programación Orientada a Objetos, base de datos relacional, arquitectura por capas, operaciones CRUD, validaciones, manejo de excepciones y conexión con SQL Server.

**Estudiante(s):JHON ALEJANDRO BENAVIDES TIBATA
**Programa:** INGENERIA DE SISTEMAS 
**Grupo:** 54467
**Docente:** VERONICA CASTRO
**Institución:** CUN - Corporación Unificada Nacional de Educación Superior
**Año:** 2026

---

## TABLA DE CONTENIDO

1. Introducción
2. Objetivos
    - 2.1 Objetivo general
    - 2.2 Objetivos específicos
3. Planteamiento del problema
4. Análisis de requerimientos
5. Casos de uso
6. Diagrama de clases
7. Modelo entidad-relación
8. Diccionario de datos
9. Arquitectura del sistema
10. Explicación de los módulos desarrollados
11. Capturas de pantalla del sistema
12. Pruebas de funcionamiento
13. Conclusiones
14. Recomendaciones
15. Referencias bibliográficas

---

## 1. INTRODUCCIÓN

El presente documento describe el desarrollo del **Sistema de Gestión de Biblioteca**, una aplicación de escritorio cuyo propósito es facilitar la administración integral del inventario de libros, el registro de usuarios y el control de préstamos y devoluciones dentro de la institución. 

El sistema fue desarrollado utilizando **C# .NET bajo Windows Forms y SQL Server**, aplicando principios avanzados de Programación Orientada a Objetos (incluyendo polimorfismo, herencia y encapsulamiento) y estructurado bajo una **arquitectura de 3 capas** (Presentación, Lógica de Negocio y Acceso a Datos).

La aplicación permite gestionar el CRUD completo de libros, autores, categorías y usuarios, así como el flujo transaccional de préstamos y devoluciones, garantizando la integridad referencial de los datos y el manejo adecuado de excepciones.

---

## 2. OBJETIVOS

### 2.1 Objetivo general

Desarrollar un Sistema de Gestión de Biblioteca que permita digitalizar y automatizar el control de inventario y préstamos de material bibliográfico, utilizando Programación Orientada a Objetos en C#, una base de datos relacional en SQL Server y una arquitectura por capas.

### 2.2 Objetivos específicos

- Diseñar e implementar una aplicación de escritorio para la gestión de libros, autores, usuarios y transacciones.
- Aplicar principios de Programación Orientada a Objetos (Herencia, Polimorfismo, Encapsulamiento).
- Diseñar e implementar una base de datos relacional robusta en SQL Server.
- Implementar operaciones CRUD completas para las entidades principales.
- Integrar validaciones de datos en formularios para evitar inconsistencias.
- Implementar bloques `try-catch` para un manejo de excepciones seguro y controlado.
- Aplicar una arquitectura por capas para desacoplar la interfaz de la lógica y los datos.
- Utilizar Git y GitHub para el control de versiones y entrega del código fuente.

---

## 3. PLANTEAMIENTO DEL PROBLEMA

### 3.1 Descripción del problema

La biblioteca presentaba dificultades para administrar de manera organizada la información relacionada con los libros, autores, usuarios y los historiales de préstamos. El manejo manual o mediante hojas de cálculo de esta información generaba pérdida de datos, redundancia, errores humanos en el registro de devoluciones y nula visibilidad en tiempo real sobre la disponibilidad del catálogo.

Por esta razón, se propone desarrollar una aplicación que permita centralizar y administrar la información de la biblioteca de manera organizada y eficiente, centralizando la información en un motor de base de datos relacional, automatizando la actualización de stock y controlando los ejemplares.

### 3.2 Justificación

El desarrollo de este sistema elimina los errores de registro manual y optimiza el tiempo del personal bibliotecario. Además, a nivel académico, permite consolidar los conocimientos adquiridos en el curso de Programación Avanzada mediante la resolución de un problema real del entorno educativo.

### 3.3 Alcance

El sistema permitirá:
- Gestionar libros.
- Gestionar autores.
- Gestionar editoriales.
- Gestionar usuarios.
- Registrar préstamos.
- Registrar devoluciones.
- Consultar historial de préstamos y generar reportes.

### Fuera del alcance
- Cobro de multas a través de pasarelas de pago electrónico.
- Módulo web o aplicación móvil para usuarios finales.

---

## 4. ANÁLISIS DE REQUERIMIENTOS

### 4.1 Descripción general
El Sistema de Gestión de Biblioteca permitirá administrar la información relacionada con libros, autores, editoriales y usuarios, y controlar los procesos de préstamos y devoluciones.

### 4.2 Actores del sistema

| Actor | Descripción |
| :--- | :--- |
| **Bibliotecario / Administrador** | Tiene acceso total al sistema. Gestiona el catálogo, los usuarios, y aprueba los préstamos y devoluciones. |

### 4.3 Requerimientos funcionales

| Código | Requerimiento | Descripción |
| :--- | :--- | :--- |
| **RF01** | Gestionar libros | Registrar, consultar, actualizar, eliminar y buscar libros. |
| **RF02** | Gestionar autores | Registrar, consultar, actualizar y eliminar autores. |
| **RF03** | Gestionar editoriales| Registrar, consultar, actualizar y eliminar editoriales. |
| **RF04** | Gestionar usuarios | Registrar, consultar, actualizar y eliminar usuarios. |
| **RF05** | Registrar préstamos | Registrar préstamos y asociar libros con usuarios. |
| **RF06** | Registrar devoluciones| Registrar devoluciones y actualizar el estado del préstamo. |
| **RF07** | Realizar consultas | Consultar reportes y visualizar registros del sistema. |

### 4.4 Requerimientos no funcionales

| Código | Requerimiento | Descripción |
| :--- | :--- | :--- |
| **RNF01**| Usabilidad | La interfaz debe ser clara, sencilla y fácil de utilizar (Windows Forms). |
| **RNF02**| Validación | El sistema debe validar la información ingresada por el usuario. |
| **RNF03**| Mantenibilidad | El código debe estar organizado y documentado. |
| **RNF04**| Arquitectura | El sistema debe utilizar una arquitectura por capas. |
| **RNF05**| Manejo de excepciones | Las operaciones deben manejar errores de forma controlada. |
| **RNF06**| Integridad de datos | La información debe mantenerse consistente en la base de datos. |

### 4.5 Reglas de negocio

**RN01 -- Campos obligatorios**
No se permitirá almacenar registros con campos obligatorios vacíos (ej. nombre de usuario, título del libro).

**RN02 -- Llaves foráneas**
No se podrá eliminar un libro o un usuario si tiene préstamos activos asociados para garantizar la integridad referencial.

**RN03 -- Relaciones válidas**
Al registrar un libro, el autor y la editorial asignados deben existir previamente en el sistema.

---

## 5. CASOS DE USO

### 5.1 Descripción
Los casos de uso describen la interacción principal del bibliotecario con el sistema para gestionar préstamos y el inventario.

### 5.2 Diagrama de casos de uso
![Diagrama de casos de uso](imagenes/casos_uso.png) 
*(Nota: Asegúrate de tener una imagen con este nombre en tu carpeta "imagenes")*

### 5.3 Descripción de casos de uso

**CU01 -- Gestionar libros**
**Actor principal:** Bibliotecario / Administrador
**Descripción:** Permite registrar, consultar, actualizar, eliminar y buscar libros.
**Flujo principal:**
1. El actor ingresa al módulo de libros.
2. El sistema muestra los libros registrados.
3. El actor selecciona la operación (Ej. Guardar nuevo libro).
4. El sistema procesa y valida la solicitud.
5. El sistema muestra el resultado en la tabla (DataGridView).

**CU02 -- Registrar préstamo**
**Actor principal:** Bibliotecario / Administrador
**Descripción:** Permite registrar el préstamo de un libro a un usuario.
**Flujo principal:**
1. Seleccionar usuario.
2. Seleccionar libro.
3. Registrar préstamo.
4. Guardar en base de datos.
5. Mostrar mensaje de confirmación.

---

## 6. DIAGRAMA DE CLASES

### 6.1 Descripción
El sistema utiliza clases para modelar las entidades del mundo real y gestionar la lógica de acceso a datos.

### 6.2 Diagrama de clases
![Diagrama de clases](imagenes/diagrama_clases.png)

### 6.3 Principales clases
| Clase | Responsabilidad |
| :--- | :--- |
| **Libro** | Representar y gestionar la información de los libros. |
| **Autor** | Representar y gestionar los autores. |
| **Editorial** | Representar las editoriales de los libros. |
| **Usuario** | Representar los usuarios de la biblioteca. |
| **Prestamo** | Gestionar la información de los préstamos. |
| **Persona** | Clase base para aplicar herencia a Usuarios y Autores. |

### 6.4 Aplicación de POO
- **Clases y Objetos:** Representación de entidades de la base de datos.
- **Encapsulamiento:** Propiedades privadas expuestas mediante `get` y `set`.
- **Herencia:** Creación de una clase base `Persona` de la cual heredan `Usuario` y `Autor`.
- **Polimorfismo:** Sobrescritura del método `ObtenerResumen()` en las clases hijas para demostrar comportamientos distintos.

---

## 7. MODELO ENTIDAD-RELACIÓN

### 7.1 Descripción
El modelo relacional garantiza que la información no esté duplicada y mantenga su integridad.

### 7.2 Diagrama entidad-relación
![Modelo entidad-relación](imagenes/modelo_er.png)

### 7.3 Relaciones principales
- Un **Autor** puede tener muchos **Libros** (1:N).
- Una **Editorial** puede publicar muchos **Libros** (1:N).
- Un **Usuario** puede realizar muchos **Préstamos** (1:N).
- Un **Libro** puede estar en muchos **Préstamos** (1:N).

---

## 8. DICCIONARIO DE DATOS

### 8.1 Convenciones
| Abreviatura | Significado |
| :--- | :--- |
| PK | Clave primaria |
| FK | Clave foránea |
| UQ | Campo con valor único |
| NULL | Campo que puede estar vacío |
| NOT NULL | Campo obligatorio |

### 8.2 Tabla: Autores
| Campo | Tipo de dato | Clave | Nulo | Descripción |
| :--- | :--- | :--- | :--- | :--- |
| IdAutor | INT | PK | No | Identificador (IDENTITY). |
| Nombre | VARCHAR(100) | - | No | Nombre del autor. |
| Apellido | VARCHAR(100) | - | No | Apellidos del autor. |

### 8.3 Tabla: Editoriales
| Campo | Tipo de dato | Clave | Nulo | Descripción |
| :--- | :--- | :--- | :--- | :--- |
| IdEditorial | INT | PK | No | Identificador (IDENTITY). |
| Nombre | VARCHAR(150) | - | No | Nombre de la editorial. |

### 8.4 Tabla: Libros
| Campo | Tipo de dato | Clave | Nulo | Descripción |
| :--- | :--- | :--- | :--- | :--- |
| ISBN | VARCHAR(20) | PK | No | Código único del libro. |
| Titulo | VARCHAR(200) | - | No | Título del libro. |
| IdAutor | INT | FK | No | Autor asociado. |
| IdEditorial | INT | FK | No | Editorial asociada. |
| Categoria | VARCHAR(100) | - | Sí | Género literario. |
| Anio | INT | - | Sí | Año de publicación. |
| Existencias | INT | - | No | Cantidad de ejemplares. |

### 8.5 Tabla: Usuarios
| Campo | Tipo de dato | Clave | Nulo | Descripción |
| :--- | :--- | :--- | :--- | :--- |
| IdUsuario | INT | PK | No | Identificador (IDENTITY). |
| Nombre | VARCHAR(100) | - | No | Nombre del usuario. |
| Apellido | VARCHAR(100) | - | No | Apellidos del usuario. |
| Documento | VARCHAR(30) | UQ | No | Número de documento. |
| Telefono | VARCHAR(30) | - | Sí | Teléfono de contacto. |
| Correo | VARCHAR(150) | - | Sí | Correo electrónico. |

### 8.6 Tabla: Prestamos
| Campo | Tipo de dato | Clave | Nulo | Descripción |
| :--- | :--- | :--- | :--- | :--- |
| IdPrestamo | INT | PK | No | Identificador (IDENTITY). |
| IdUsuario | INT | FK | No | Usuario del préstamo. |
| ISBN | VARCHAR(20) | FK | No | Libro prestado. |
| FechaPrestamo | DATE | - | No | Fecha inicial. |
| FechaDevolucion| DATE | - | Sí | Fecha de entrega. |
| Estado | VARCHAR(20) | - | No | Ej: 'Prestado', 'Devuelto'. |

---

## 9. ARQUITECTURA DEL SISTEMA

### 9.1 Descripción general
El Sistema se desarrolla utilizando una **arquitectura por capas**, con el propósito de separar responsabilidades, facilitando su mantenimiento y evolución.

1. Capa de Presentación (Formularios UI).
2. Capa de Lógica de Negocio / Entidades.
3. Capa de Acceso a Datos (DAL).

### 9.2 Capa de Presentación
**Responsabilidad:** Interfaz con el usuario.
**Componentes:** Formularios (FrmMenuPrincipal, FormLibros, FormUsuarios, etc.).
**Tecnología:** C# Windows Forms.

### 9.3 Capa de Acceso a Datos y Lógica
**Responsabilidad:** Gestiona la comunicación con SQL Server y aplica reglas.
**Componentes:** Archivos `CD_Conexion`, `CD_Libros`, clases Entidades.
**Tecnologías:** ADO.NET, Consultas SQL parametrizadas para evitar inyecciones.

### 9.4 Flujo de información
```text
Usuario (Interfaz gráfica)
   ↓
Lógica y Validaciones (C#)
   ↓
Acceso a Datos (ADO.NET)
   ↓
Base de Datos (SQL Server)
```

---

## 10. EXPLICACIÓN DE CADA MÓDULO DESARROLLADO

- **Módulo de libros:** Permite gestionar el catálogo mediante un CRUD y un buscador dinámico que filtra por ISBN o Título.
- **Módulos base (Autores, Editoriales, Usuarios):** Formularios CRUD estándar para poblar las tablas maestras, garantizando que haya información disponible para los préstamos.
- **Módulo de préstamos:** Eje central del sistema; vincula la información de Usuarios y Libros, estableciendo un registro histórico y controlando el estado del material ("Prestado" o "Devuelto").
- **Módulo de reportes:** Permite visualizar los registros consolidados utilizando consultas relacionales (`JOIN` en SQL).

---

## 11. CAPTURAS DE PANTALLA DEL SISTEMA


### 11.1 Menú principal
![Menú principal](imagenes/menu_principal.png)
**Descripción:** Interfaz de inicio con navegación a todos los módulos.

### 11.2 Gestión de libros
![Gestión de libros](imagenes/form_libros.png)
**Descripción:** Formulario con DataGridView, botones de acción y manejo de errores visible al intentar eliminar registros ligados.

### 11.3 Prueba de Polimorfismo
![Prueba Polimorfismo](imagenes/prueba_polimorfismo.png)
**Descripción:** Demostración de herencia y polimorfismo en tiempo de ejecución.

---

## 12. PRUEBAS DE FUNCIONAMIENTO

### 12.1 Estrategia de pruebas
Se ejecutó un circuito completo simulando el flujo real: Creación de catálogos base -> Creación de Libros -> Préstamo -> Validación de restricciones.

### 12.2 Casos de prueba

| ID | Funcionalidad | Acción | Resultado esperado | Estado |
| :--- | :--- | :--- | :--- | :--- |
| **CP01** | Guardar Libro | Datos válidos | Aparece en el DataGridView | Aprobado |
| **CP02** | Editar Libro | Cambiar título | Se actualiza en tiempo real | Aprobado |
| **CP03** | Integridad Relacional| Borrar libro prestado| Muestra advertencia amarilla | Aprobado |
| **CP04** | Eliminación Cascada | Borrar préstamo y libro| Se elimina correctamente | Aprobado |
| **CP05** | Polimorfismo | Ejecutar método base | Retorna textos diferenciados | Aprobado |

---

## 13. CONCLUSIONES

1. Se logró desarrollar un sistema funcional robusto en C# que cumple satisfactoriamente con los requerimientos propuestos para la biblioteca.
2. La aplicación práctica de la Programación Orientada a Objetos facilitó la reutilización de código (Herencia) y la adaptación de comportamientos (Polimorfismo).
3. El manejo avanzado de base de datos (Eliminación en cascada y validaciones Try-Catch) garantiza que la aplicación no sufra cierres inesperados, brindando una experiencia de usuario profesional.
4. El uso de la arquitectura en capas asegura que el sistema sea escalable y fácil de mantener a futuro.

---

## 14. RECOMENDACIONES

- Implementar un sistema de Login para tener roles de seguridad (ej. Solo el administrador puede borrar libros).
- Incorporar generación de reportes en PDF utilizando librerías como iTextSharp.
- Desarrollar un dashboard gráfico en el Menú Principal que muestre estadísticas rápidas (Libros más prestados, total de usuarios).

---

## 15. REFERENCIAS BIBLIOGRÁFICAS

Microsoft. (2026). *Documentación de C# y .NET*. Microsoft Learn. Recuperado de https://learn.microsoft.com/es-es/dotnet/csharp/

Microsoft. (2026). *ADO.NET Arquitectura y conexión a SQL Server*. Microsoft Learn.

---

## ANEXOS

**Anexo A. Repositorio GitHub**
**Repositorio:** [Coloca aquí el link a tu repositorio de GitHub]

**Anexo B. Script de base de datos**
**Archivo:** `AcaBiblioteca_Script.sql`

**Anexo C. Evidencia de Git y GitHub**
(Adjuntar capturas de los commits y el repositorio online).