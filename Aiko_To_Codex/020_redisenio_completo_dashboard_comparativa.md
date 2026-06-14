# 020 - Rediseño completo del dashboard desde comparativa

Estado: lista para Codex
Fecha: 2026-06-14

## Contexto

La tarea 019 mejoro el aspecto, pero la app todavia no alcanza la estructura del dashboard deseado. Fak preparo una comparativa detallada entre la interfaz actual y la interfaz objetivo.

Esta tarea sustituye el enfoque de "pulido visual" por un rediseño ordenado de la pantalla principal, manteniendo WinForms y sin romper funciones.

## Prioridad absoluta

Antes de seguir con nuevas funciones, resolver:

1. Botones cortados u ocultos.
2. Botones sin accion clara.
3. Falta de scroll en paneles largos.
4. Ventana debe abrir maximizada.
5. El flujo debe entenderse sin explicacion externa.

## Objetivo visual

Acercar la pantalla Inicio al dashboard premium aprobado:

- sidebar completa;
- header compacto;
- tarjeta de fecha + frase motivacional;
- flujo de trabajo diario visual;
- estado de hoy con tarjetas reales;
- progreso semanal 2 videos;
- distribucion de contenido;
- ultimos elementos;
- recomendacion de Aiko como tarjeta destacada;
- acciones rapidas en cuadricula;
- tareas para hoy con checkbox y prioridad;
- footer con WordPress draft, proyecto activo y version.

## Header

Cambiar el header a:

- saludo: `Hola, Fak 👋`;
- subtitulo: `Centro de mando editorial de AikoGx`;
- tarjeta unica con fecha + frase motivacional;
- iconos/botones para notificaciones, ayuda y ajustes;
- toggle visual de modo oscuro;
- quitar el estado WordPress del header y moverlo al footer;
- reformular la recomendacion para que no aparezca como texto suelto.

## Sidebar

Usar este orden:

- Inicio
- Notas del Dia
- Devlogs
- Discord
- X (Twitter)
- TikTok / Shorts
- itch.io
- Ideas / Content Bank
- Tareas
- Calendario
- Archivos y Material
- Estado del Proyecto
- Ajustes

Abajo añadir tarjeta Proyecto Actual:

- Caos Entre Reinos
- RPG | Estrategia | Cartas
- imagen o placeholder oscuro si no hay imagen real
- boton `Ver detalles del proyecto`

## Inicio / Dashboard

La pantalla Inicio debe mostrar resumen general, no solo un bloque para pegar texto.

Secciones esperadas:

### Flujo de trabajo diario

5 pasos visuales:

1. Capturar
2. Organizar
3. Recomendar
4. Crear contenido
5. Publicar / revisar

Debe ser informativo, no necesariamente tabs.

### Estado de hoy

Tarjetas con valores reales:

- Notas del dia
- Ideas generadas
- Contenido listo

Si se mantienen capturas, videos, analisis, paquete Aiko y WordPress, deben mostrarse como datos utiles, no etiquetas vacias.

### Progreso semanal

Añadir bloque:

- Objetivo: 2 videos
- contador tipo `0/2`, `1/2`, `2/2`
- checkmarks por dias de semana si es posible

### Distribucion de contenido

Añadir bloque simple con porcentajes por plataforma.

No hace falta grafico perfecto; si WinForms lo complica, usar barras o lista visual:

- TikTok / Shorts
- Discord
- Devlog
- X
- itch.io

### Ultimos elementos

Lista de notas, ideas, contenido creado y publicaciones recientes.

Debe mostrar texto, hora y etiqueta.

## Analizar con Aiko

Mantener la funcion `Pegar paquete para Aiko` y `Analizar con Aiko`, pero no debe dominar el inicio.

Opciones validas:

- moverlo a seccion `Notas del Dia` o `Analizar`;
- dejarlo en Inicio pero en una card secundaria;
- mantener acceso desde Acciones Rapidas.

## Diagnostico y previews

Corregir formato del diagnostico.

Ahora sale texto concatenado. Debe verse con secciones separadas:

- RESUMEN DEL DIA
- MATERIAL DETECTADO
- RECOMENDACION
- MOTIVO
- QUE FALTA ANTES DE PUBLICAR

Aplicar espaciado y saltos de linea.

Las tabs inferiores deben ser legibles y no romper el tema oscuro.

## Panel derecho

### Recomendacion de Aiko

Debe verse como tarjeta destacada:

- titulo `Recomendacion de Aiko`;
- plataforma recomendada;
- motivo breve;
- idea destacada;
- boton `Ver idea completa` o accion equivalente.

### Acciones rapidas

Reemplazar `Herramientas avanzadas` por `Acciones rapidas`.

Botones en cuadricula:

- Nueva nota
- Nuevo devlog
- Nueva idea
- Agregar captura
- Agregar video
- Generar Content Bank

### Para hacer hoy

Lista con:

- contador de tareas pendientes;
- checkbox;
- texto;
- prioridad Alta / Media / Baja.

## Footer

Añadir footer con:

- WordPress: Conectado / Draft seguro;
- Proyecto: Caos Entre Reinos;
- estado/hora actual;
- AikoGx System v2.0.

## Funcionalidad

Revisar todos los botones visibles:

- Si tienen funcion real, mantenerla y probarla.
- Si no tienen funcion, deshabilitarlos visualmente o mostrar mensaje `Pendiente`.
- Ningun boton debe parecer funcional si no hace nada.

## Scroll y responsive

- La app debe abrir maximizada.
- Añadir scroll vertical en paneles donde el contenido pueda exceder el tamaño visible.
- Evitar botones cortados.
- Evitar contenido inaccesible.
- Probar en ventana maximizada y tamaño reducido razonable.

## Seguridad

- Mantener WinForms .NET 8.
- No migrar tecnologia.
- No romper WordPress draft.
- No publicar automaticamente.
- No conectar GitHub automaticamente.
- Usar solo Fak como nombre visible.

## Validacion

Probar manualmente:

- abrir app maximizada;
- guardar nota;
- importar captura;
- importar video;
- organizar notas;
- analizar;
- generar paquete Aiko;
- guardar respuesta;
- generar Content Bank;
- crear borrador manual/WordPress draft;
- abrir carpetas/resultados;
- comprobar que no hay botones cortados.

Ejecutar:

```text
dotnet build -c Release
```

Y publicar exe:

```text
dotnet publish -c Release -r win-x64 --self-contained true -o publish\win-x64
```

## Entrega

Crear resumen en:

```text
Codex_Review/020_redisenio_completo_dashboard_comparativa_resumen.md
```

El resumen debe indicar:

- que se corrigio funcionalmente;
- que se cambio visualmente;
- que botones siguen pendientes y por que;
- pruebas realizadas;
- limitaciones de WinForms si existen.
