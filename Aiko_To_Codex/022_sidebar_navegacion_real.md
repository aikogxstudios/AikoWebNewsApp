# 022 - Sidebar con navegacion real

Estado: lista para Codex
Fecha: 2026-06-14

## Contexto

Fak reviso la app y la sidebar actual da la sensacion de ser un menu real, pero muchas secciones no cambian el panel central o no comunican claramente si estan pendientes. Eso confunde.

La sidebar debe ser el mapa real de la app, no decoracion.

## Objetivo

Hacer que la sidebar tenga comportamiento claro:

- Si una seccion existe, debe cambiar el contenido central.
- Si una seccion no existe todavia, debe mostrar una pantalla/panel `Pendiente` con explicacion.
- Ningun boton debe parecer roto o sin efecto.

## Secciones minimas funcionales

Implementar como minimo pantallas reales o paneles claros para:

1. Inicio
2. Notas del Dia
3. Ideas / Content Bank
4. Tareas
5. Archivos y Material
6. Estado del Proyecto
7. Ajustes

Las demas secciones pueden mostrar panel pendiente:

- Devlogs
- Discord
- X (Twitter)
- TikTok / Shorts
- itch.io
- Calendario

## Comportamiento esperado

### Inicio

Muestra dashboard resumen.

### Notas del Dia

Muestra zona de notas, pegar paquete, analizar con Aiko, guardar nota y notas organizadas.

### Ideas / Content Bank

Muestra botones y resultados de Content Bank:

- Generar Content Bank
- Abrir carpeta Content Bank
- Ver ideas generadas si existen
- Ver `esta_semana.md` si existe

### Tareas

Muestra checklist de tareas para hoy con prioridad.

### Archivos y Material

Muestra capturas, videos y boton para abrir carpetas.

### Estado del Proyecto

Muestra proyecto actual:

- Caos Entre Reinos
- estado editorial
- WordPress draft seguro
- objetivo semanal
- pendiente de pantalla completa si no hay mas datos

### Ajustes

Abre o muestra configuracion local.

## Sidebar visual

- Mantener scroll si hace falta.
- Evitar barra blanca fea si es posible.
- Marcar visualmente la seccion activa.
- Si un boton lleva a panel pendiente, mostrarlo claro.

## Reglas

- Mantener WinForms .NET 8.
- No migrar tecnologia.
- No publicar automaticamente.
- WordPress siempre draft.
- No conectar GitHub automaticamente.
- Usar solo Fak como nombre visible.

## Validacion

Probar clic en cada boton de sidebar.

Cada click debe hacer una de estas dos cosas:

- cambiar a una seccion funcional;
- mostrar panel `Pendiente` claro.

No debe haber botones mudos.

Ejecutar:

```text
dotnet build -c Release
```

Publicar exe:

```text
dotnet publish -c Release -r win-x64 --self-contained true -o publish\win-x64
```

## Entrega

Crear resumen en:

```text
Codex_Review/022_sidebar_navegacion_real_resumen.md
```
