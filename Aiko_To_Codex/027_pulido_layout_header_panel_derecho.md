# 027 - Pulido layout header y panel derecho

Estado: lista para Codex
Fecha: 2026-06-15

## Contexto

Tras la tarea 026, la app mejoro visualmente con iconos. Fak reviso capturas del ejecutable y encontro varios problemas simples de layout.

Esta tarea debe corregir solo esos problemas visuales concretos.

No hacer redisenio completo.

## Problemas detectados

### 1. Header superior

En la barra superior, la frase de fecha/mensaje se superpone o queda demasiado cerca del boton `Avisos`.

Ahora mismo se ve como:

```text
2026-06-15 | Buen dia para convertir notas en contenido claro. [Avisos] [Ayuda] [Ajustes]
```

Pero el bloque de texto invade el espacio de los botones.

### 2. Botones del header

Los tres botones:

- `Avisos`
- `Ayuda`
- `Ajustes`

deben estar alineados al final/derecha de la barra superior, no pegados al texto central.

### 3. Card `Recomendacion de Aiko`

En la card de recomendacion aparece un elemento raro en la esquina inferior derecha: parece una linea/boton morado escondido o un adorno que no se entiende.

Fak no sabe que pretende comunicar y visualmente parece un boton oculto o un fallo.

Hay que quitarlo o sustituirlo por algo claro.

Preferencia: quitar ese elemento decorativo/oculto y dejar la card limpia.

### 4. Panel `Acciones rapidas`

El panel de acciones rapidas esta desaprovechando espacio.

Problemas:

- aparece una barra de scroll interna innecesaria;
- los botones ocupan poco espacio;
- la zona podria mostrar mas contenido sin scroll;
- `Ultimos elementos` queda demasiado arriba y corta el flujo visual.

## Objetivo

Pulir el layout del dashboard para que:

- el header no tenga solapes;
- los botones del header queden a la derecha;
- la card de recomendacion no tenga controles/adornos confusos;
- `Acciones rapidas` use todo el espacio disponible;
- `Ultimos elementos` quede mas abajo, idealmente al fondo del panel derecho;
- no haya barras de scroll internas innecesarias en el panel derecho.

## Trabajo solicitado

### A. Header

Ajustar el layout superior para que tenga tres zonas claras:

```text
[Hola, Fak + subtitulo]    [fecha + frase con ancho controlado]    [Avisos] [Ayuda] [Ajustes]
```

Reglas:

- Los botones `Avisos`, `Ayuda`, `Ajustes` deben estar anclados al extremo derecho.
- La frase central debe tener ancho limitado o usar ellipsis si no cabe.
- Nunca debe tapar ni invadir los botones.
- Mantener altura compacta.
- Mantener estilo oscuro AikoGx.

### B. Recomendacion de Aiko

Eliminar el elemento morado raro/oculto de la esquina inferior derecha.

Si ese elemento era decorativo, quitarlo.

Si era un boton funcional, convertirlo en un boton claro con texto visible o moverlo a una zona entendible. Pero preferencia actual: quitarlo y dejar la card limpia.

La card debe mostrar solo:

- titulo;
- recomendacion;
- motivo;
- siguiente paso;
- opcionalmente un boton claro si ya existe funcion real.

### C. Acciones rapidas

Reorganizar el panel derecho para aprovechar el espacio.

Propuesta:

- `Acciones rapidas` arriba.
- Botones en grid compacto, ocupando el ancho disponible.
- Evitar scroll interno si hay espacio suficiente.
- `Para hacer hoy` debajo de acciones, visible sin quedar cortado.
- `Ultimos elementos` abajo del todo del panel derecho o lo mas abajo posible.

No debe haber una barra de scroll blanca dentro de `Acciones rapidas` si el contenido cabe.

### D. Ultimos elementos

Mover `Ultimos elementos` hacia abajo en el panel derecho para que no robe espacio a acciones rapidas.

Debe verse como seccion secundaria, no como bloque principal.

## Reglas importantes

- No tocar logica principal.
- No tocar WordPress salvo que sea necesario para compilar.
- Mantener WordPress siempre en draft.
- No publicar automaticamente.
- No conectar GitHub desde la app.
- No migrar a WPF/WinUI.
- No usar todavia Krypton ni ReaLTaiizor.
- No redisenar toda la app.
- Mantener cambios en `Form1.cs` o archivos actuales necesarios.
- Usar solo `Fak` como nombre visible.

## Validacion

Ejecutar:

```text
dotnet restore
dotnet build -c Release
dotnet publish -c Release -r win-x64 --self-contained true -o publish\win-x64
```

Validar visualmente:

- Header sin solapes.
- Botones del header al extremo derecho.
- Frase central no tapa ningun boton.
- Card de recomendacion sin boton/adornos escondidos.
- Acciones rapidas sin scroll interno innecesario.
- Acciones rapidas aprovecha el espacio.
- Ultimos elementos queda mas abajo.
- No se rompen botones ni navegacion.

## Entrega

Crear resumen en:

```text
Codex_Review/027_pulido_layout_header_panel_derecho_resumen.md
```

El resumen debe indicar:

- archivos modificados;
- cambios hechos en header;
- cambios hechos en recomendacion;
- cambios hechos en panel derecho;
- resultado de restore/build/publish;
- si quedaron pendientes visuales.
