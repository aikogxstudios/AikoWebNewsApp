# 028 - Arreglar panel derecho: acciones rapidas, tareas y ultimos elementos

Estado: lista para Codex
Fecha: 2026-06-15

## Contexto

Fak reviso una captura tras la tarea 027. El header ya mejoro, pero el panel derecho sigue teniendo problemas visuales concretos.

Esta tarea debe corregir SOLO el panel derecho del dashboard.

No tocar sidebar, header, WordPress, Content Bank ni logica principal salvo que sea necesario para mantener eventos existentes.

## Problemas detectados en la captura

### 1. Acciones rapidas desaprovecha ancho

El panel `Acciones rapidas` tiene mucho espacio libre a la derecha.

Los botones estan en dos columnas pequenas y no aprovechan el ancho disponible.

### 2. `Para hacer hoy` queda cortado

El titulo dice `Para hacer hoy (3)`, pero no se ven las 3 tareas completas.

Se ven parcialmente:

- `Pegar paquete completo`
- `Analizar con Aiko`
- una tercera tarea cortada

Esto debe arreglarse: si se muestran 3 tareas, las 3 deben verse completas.

### 3. `Ultimos elementos` es demasiado grande/vacio

`Ultimos elementos` se movio hacia abajo, pero ahora ocupa una caja grande con mucho espacio vacio.

Debe ser una seccion secundaria compacta en la parte baja del panel derecho.

### 4. Panel inferior vacio con barra blanca

Debajo de `Ultimos elementos` aparece una zona grande vacia con barras blancas/scroll.

Parece un contenedor sobrante o mal calculado.

Hay que eliminarlo, ocultarlo si no tiene contenido o redimensionarlo para que no se vea como fallo visual.

## Objetivo

El panel derecho debe quedar limpio y util:

```text
[Acciones rapidas]
- botones grandes o mejor distribuidos usando todo el ancho

[Para hacer hoy]
- mostrar todas las tareas visibles sin corte

[Ultimos elementos]
- bloque compacto abajo

(no paneles vacios ni barras blancas innecesarias)
```

## Trabajo solicitado

### A. Acciones rapidas

Reorganizar los botones para aprovechar mejor el espacio horizontal.

Opciones validas:

- 2 columnas mas anchas ocupando casi todo el panel;
- o 3 columnas si el ancho lo permite;
- o botones de ancho fluido calculado segun panel.

No dejar la mitad derecha vacia.

Botones actuales esperados:

- Nueva nota
- Nuevo devlog
- Nueva idea
- Agregar captura
- Agregar video
- Content Bank

Todos deben seguir funcionando igual.

### B. Para hacer hoy

Asegurar que las tareas visibles no se cortan.

Reglas:

- Si el contador dice `(3)`, se deben ver las 3 tareas completas.
- La etiqueta de prioridad (`Alta`, `Media`, etc.) debe quedar alineada y visible.
- No debe aparecer cortada por el borde inferior del panel.
- Evitar scroll interno si solo son 3 tareas.

Si no cabe, reducir altura de otras secciones antes de cortar tareas.

### C. Ultimos elementos

Convertir `Ultimos elementos` en un bloque compacto abajo.

Reglas:

- Debe estar abajo o casi abajo.
- No debe ocupar una caja enorme vacia.
- Altura sugerida: solo la necesaria para titulo + lista de 4/5 elementos.
- Si no hay elementos, mostrar texto simple tipo `Sin elementos recientes`.

### D. Eliminar panel vacio inferior

Quitar/ocultar/redimensionar el bloque vacio que aparece debajo de `Ultimos elementos`.

No deben verse barras blancas grandes ni scrollbars internas sin contenido.

## Reglas importantes

- No tocar logica principal.
- No tocar WordPress salvo compilacion.
- WordPress sigue siempre en `draft`.
- No publicar automaticamente.
- No conectar GitHub desde la app.
- No migrar a WPF/WinUI.
- No usar todavia Krypton ni ReaLTaiizor.
- No redisenar toda la app.
- Mantener los iconos FontAwesome existentes.
- Usar solo `Fak` si aparece nombre visible.

## Validacion visual

Comprobar en la pantalla Inicio/dashboard:

- `Acciones rapidas` usa bien el ancho del panel derecho.
- No aparece scroll interno en acciones rapidas si no hace falta.
- `Para hacer hoy (3)` muestra las 3 tareas completas.
- `Ultimos elementos` queda compacto abajo.
- No aparece un panel vacio debajo.
- No hay barras blancas innecesarias.
- Los botones siguen funcionando.

## Validacion tecnica

Ejecutar:

```text
dotnet restore
dotnet build -c Release
dotnet publish -c Release -r win-x64 --self-contained true -o publish\win-x64
```

## Entrega

Crear resumen en:

```text
Codex_Review/028_arreglar_panel_derecho_acciones_tareas_resumen.md
```

El resumen debe indicar:

- archivos modificados;
- cambios en acciones rapidas;
- cambios en tareas;
- cambios en ultimos elementos;
- si se elimino/oculto el panel vacio inferior;
- resultado de restore/build/publish;
- si quedan pendientes visuales.
