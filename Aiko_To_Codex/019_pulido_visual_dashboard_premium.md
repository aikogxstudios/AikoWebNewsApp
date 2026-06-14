# 019 - Pulido visual dashboard premium

Estado: lista para Codex
Fecha: 2026-06-14

## Contexto

La tarea 017 dejo una base funcional oscura, pero visualmente sigue pareciendo una app WinForms clasica con colores. Fak aprobo una direccion visual mucho mas cercana a un dashboard premium de AikoGx: oscuro, limpio, morado, con sidebar, cards y panel de recomendacion.

Esta tarea NO es para rehacer sistemas. Es para acercar la UI al concepto aprobado sin romper funciones.

## Objetivo

Mejorar la interfaz principal para que se parezca mas a un centro de mando editorial moderno.

## Problemas actuales detectados

- Falta sidebar izquierda de navegacion.
- El header ocupa mucho espacio y no tiene estructura tipo dashboard.
- Las cards son rectangulos muy planos y separados sin jerarquia visual.
- Los tabs se ven blancos/clasicos y rompen el tema oscuro.
- El panel de notas ocupa demasiado y deja la app desequilibrada.
- Falta un panel claro de Recomendacion de Aiko.
- Las acciones no parecen cards premium ni acciones rapidas.
- Falta sensacion de flujo visual horizontal tipo Capturar -> Organizar -> Recomendar -> Crear.
- Falta zona de tareas para hoy / siguiente paso.

## Direccion visual obligatoria

- Fondo oscuro profundo.
- Acentos morado, azul y magenta.
- Sidebar izquierda fija de 220-260 px.
- Header compacto con saludo a Fak, fecha y modo seguro.
- Area central con flujo diario por pasos.
- Cards de estado con mejor padding y jerarquia.
- Panel derecho de Recomendacion de Aiko.
- Acciones rapidas en formato botones/cards.
- Vista de notas/material/contenido en la parte inferior o central, no dominando toda la pantalla.

## Layout recomendado

Estructura general:

```text
[ Sidebar ] [ Header superior compacto                         ]
[ Sidebar ] [ Flujo diario + Estado hoy      | Recomendacion    ]
[ Sidebar ] [ Notas / previews / material    | Acciones / tareas ]
[ Footer  ] [ Estado seguro / proyecto / hora                  ]
```

## Sidebar sugerida

Crear una columna visual izquierda con botones simples:

- Inicio
- Notas del Dia
- Devlogs
- Discord
- X
- TikTok / Shorts
- itch.io
- Ideas / Content Bank
- Tareas
- Calendario
- Material
- Ajustes

No hace falta que todos naveguen a pantallas reales todavia. Pueden ser botones visuales o deshabilitados si no hay seccion. Lo importante ahora es la estructura.

## Recomendacion de Aiko

Crear un panel visible que use `_recommendationLabel` y explique mejor el siguiente paso.

Ejemplo:

```text
Recomendacion de Aiko
Hoy conviene: TikTok / Shorts
Motivo: hay material visual y una idea clara.
Siguiente paso: grabar clip o revisar Content Bank.
```

## Tabs / previews

Evitar tabs blancas por defecto si se puede. Si WinForms TabControl no permite estilo fino facilmente, envolverlo en un panel oscuro o reducir su presencia visual.

Prioridad: que no rompa el tema oscuro.

## Reglas tecnicas

- Mantener WinForms .NET 8.
- No migrar a WPF, MAUI, web ni Electron.
- No romper funciones existentes.
- No tocar seguridad WordPress.
- WordPress debe seguir siempre en draft.
- No conectar GitHub automaticamente.
- Usar solo Fak como nombre visible.
- Mantener Content Bank como herramienta local.

## Validacion

Probar:

- abrir app
- crear/cargar dia
- guardar nota
- organizar notas
- analizar material
- generar paquete Aiko
- generar Content Bank
- crear borrador manual/WordPress draft

Ejecutar:

```text
dotnet build -c Release
```

Si publica exe:

```text
dotnet publish -c Release -r win-x64 --self-contained true -o publish\win-x64
```

## Entrega

Crear resumen en:

```text
Codex_Review/019_pulido_visual_dashboard_premium_resumen.md
```
