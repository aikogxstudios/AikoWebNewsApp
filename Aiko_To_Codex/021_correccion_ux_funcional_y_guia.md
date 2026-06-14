# 021 - Correccion UX funcional y guia de uso

Estado: lista para Codex
Fecha: 2026-06-14

## Contexto

La ultima version se acerca mas al concepto visual, pero todavia no funciona como producto intuitivo.

Problemas detectados por Fak en captura:

- La sidebar da sensacion de tener mas opciones abajo, pero no se puede bajar.
- Hay espacio vacio desaprovechado en la parte inferior de la sidebar.
- Botones del header parecen clicables, pero no hacen nada.
- El boton o etiqueta de modo oscuro no hace nada.
- El flujo de trabajo diario se corta; el paso 5 no se ve completo.
- El flujo deberia sentirse como una barra de progreso entre pasos, no como tarjetas cortadas.
- Estado de hoy no comunica para que sirve ni muestra valores claros.
- Progreso semanal se ve bonito pero no se entiende ni se ve completo.
- Distribucion de contenido no aporta si no esta conectada a datos reales.
- Material util se ve cortado.
- Recomendacion de Aiko se corta y parte del contenido queda inaccesible.
- Acciones rapidas se corta y no se puede bajar bien.
- Tareas para hoy tambien quedan cortadas.
- La zona inferior de Diagnostico / Notas / Web / Redes / WordPress / Material se ve fea, clasica y desorganizada.
- El diagnostico aparece como texto corrido y dificil de leer.
- La app no es intuitiva: un usuario nuevo no sabe que hacer primero.

## Objetivo

No seguir decorando. Corregir la UX funcional y hacer que la app se entienda.

La pantalla principal debe responder claramente a estas preguntas:

1. Que tengo que hacer ahora?
2. Que material tengo hoy?
3. Que recomienda Aiko?
4. Que puedo crear?
5. Donde veo el resultado?
6. Que esta listo y que necesita contexto?

## Decision de producto

La app debe tener 3 zonas claras:

### 1. Inicio / Dashboard

Vista resumen. No debe ser una pantalla llena de texto.

Debe mostrar:

- flujo del dia;
- recomendacion de Aiko;
- estado real del material;
- acciones rapidas;
- tareas para hoy;
- ultimos elementos.

### 2. Trabajo con Aiko

Zona donde se pega el paquete, se analiza y se revisa el resultado.

Puede estar en una seccion propia o card grande, pero no debe romper el dashboard.

### 3. Resultados / Material

Zona donde se ven diagnostico, notas organizadas, web, redes, WordPress, Content Bank y material.

Debe ser legible y con scroll.

## Correcciones obligatorias

### Ventana

- La app debe abrir maximizada.
- El contenido debe adaptarse a maximizado.
- Si se reduce la ventana, debe haber scroll en zonas largas.

### Sidebar

- Si hay mas items de los que caben, añadir scroll.
- Si no hay scroll, reducir items o agruparlos.
- No dejar sensacion de que hay contenido oculto sin forma de bajar.
- Aprovechar el espacio inferior.
- La tarjeta Proyecto actual debe estar completa o moverse a una zona donde no se corte.

### Header

- Los botones de campana, ayuda, ajustes y modo oscuro no deben parecer funcionales si no hacen nada.
- Opciones validas:
  - implementar accion real simple;
  - mostrar mensaje Pendiente;
  - deshabilitar visualmente;
  - eliminar temporalmente si estorban.
- El modo oscuro puede eliminarse por ahora porque toda la app ya es oscura.

### Flujo diario

- El paso 5 no puede quedar cortado.
- Reducir texto o tamaño de tarjetas.
- Hacerlo como barra de progreso horizontal con 5 puntos/pasos.
- Debe verse completo en ventana maximizada.

### Estado de hoy

- Convertirlo en tarjetas con valores reales:
  - notas;
  - capturas;
  - videos;
  - ideas generadas;
  - contenido listo;
  - WordPress draft.
- Si un dato no se calcula aun, poner Pendiente de forma clara.
- No dejar etiquetas vacias.

### Progreso semanal

- Si no hay datos reales, mostrarlo como objetivo simple.
- Evitar graficos que no se entienden.
- Mostrar: `0/2 videos esta semana` y siguiente paso.

### Distribucion de contenido

- Si no hay datos reales, no mostrar dona falsa.
- Opciones:
  - ocultarla hasta que haya datos;
  - mostrar lista simple con estado `sin datos suficientes`;
  - convertirla en card secundaria.

### Material util

- No debe cortarse.
- Mostrar capturas y videos con contadores claros.
- Boton para abrir carpeta de material.

### Recomendacion de Aiko

- No debe cortarse.
- Debe tener scroll interno si el texto crece.
- Debe mostrar:
  - recomendacion;
  - motivo;
  - siguiente paso;
  - boton principal claro.

### Acciones rapidas

- No deben quedar cortadas.
- Si hay muchas, usar grid compacto 2 columnas.
- Si no caben, meterlas en panel con scroll.

### Tareas para hoy

- Lista con checkbox y prioridad.
- Debe verse completa o tener scroll.
- Debe indicar que tarea es la primera recomendada.

### Diagnostico y tabs inferiores

- El TabControl blanco clasico rompe el diseño.
- Mejorar apariencia si es posible.
- Si no se puede, reemplazar por botones/pills arriba de un panel de texto oscuro.
- El diagnostico debe formatearse con saltos de linea y titulos claros.
- No mostrar texto concatenado.

## Guia de uso dentro de la app

Crear una guia simple accesible desde un boton `Ayuda` o seccion `Guia`.

Contenido minimo de la guia:

```text
1. Escribe o pega notas del dia.
2. Importa capturas o videos si tienes material visual.
3. Pulsa Analizar con Aiko.
4. Revisa la Recomendacion de Aiko.
5. Si falta contexto, completa la nota antes de publicar.
6. Genera paquete para Aiko o Content Bank.
7. Revisa resultados.
8. Copia manualmente o crea borrador WordPress en draft.
```

Tambien añadir texto corto en la pantalla principal:

```text
Empieza aqui: pega tus notas del dia y pulsa Analizar con Aiko.
```

## Reglas

- Mantener WinForms .NET 8.
- No migrar tecnologia.
- No publicar automaticamente.
- WordPress siempre draft.
- No conectar GitHub automaticamente.
- Usar solo Fak como nombre visible.
- Si algo aun no funciona, marcarlo como Pendiente en vez de fingir que funciona.

## Validacion

Probar visualmente:

- no hay botones cortados;
- no hay secciones inaccesibles;
- la app abre maximizada;
- la sidebar no oculta opciones sin scroll;
- la recomendacion de Aiko se lee completa;
- las acciones rapidas se ven completas;
- el diagnostico tiene formato legible;
- cada boton visible hace algo o esta marcado como pendiente.

Probar funciones:

- guardar nota;
- importar captura;
- importar video;
- analizar;
- generar paquete Aiko;
- guardar respuesta;
- generar Content Bank;
- abrir carpetas;
- crear borrador WordPress draft/manual.

Ejecutar:

```text
dotnet build -c Release
```

Y publicar:

```text
dotnet publish -c Release -r win-x64 --self-contained true -o publish\win-x64
```

## Entrega

Crear resumen en:

```text
Codex_Review/021_correccion_ux_funcional_y_guia_resumen.md
```

El resumen debe incluir:

- que se corrigio;
- que botones funcionan;
- que botones quedaron pendientes;
- como se accede a la guia;
- pruebas realizadas;
- limitaciones reales de WinForms.
