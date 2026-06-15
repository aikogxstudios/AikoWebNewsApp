# 025 - Verificar paquetes UI WinForms

Estado: lista para Codex
Fecha: 2026-06-15

## Contexto

Fak instalo paquetes NuGet para mejorar visualmente la app WinForms sin migrar todavia a WPF/WinUI.

Los paquetes que deben existir en el proyecto son:

- `FontAwesome.Sharp`
- `ReaLTaiizor`
- `Krypton.Toolkit`

Antes de usarlos en la interfaz hay que verificar que estan correctamente agregados al proyecto, que restauran bien y que no rompen compilacion/publicacion.

## Objetivo

Comprobar que los paquetes UI estan presentes y son compatibles con `AikoWebNewsApp.csproj`.

Esta tarea es solo de verificacion. No redisenar la interfaz todavia.

## Trabajo solicitado

1. Revisar `AikoWebNewsApp.csproj`.
2. Confirmar si existen estos `PackageReference`:
   - `FontAwesome.Sharp`
   - `ReaLTaiizor`
   - `Krypton.Toolkit`
3. Si alguno no esta, anadirlo con `dotnet add package`.
4. Ejecutar restauracion/build.
5. Verificar que no se suben carpetas generadas como `bin/` u `obj/` si no corresponde.
6. No tocar la UI todavia salvo que sea necesario para compilar.

## Comandos de validacion

```text
dotnet restore
dotnet build -c Release
dotnet publish -c Release -r win-x64 --self-contained true -o publish\win-x64
```

## Reglas importantes

- No usar todavia los controles de Krypton ni ReaLTaiizor en toda la app.
- No cambiar la logica de WordPress.
- No publicar automaticamente.
- No conectar GitHub desde la app.
- No migrar a WPF/WinUI.
- Mantener WinForms .NET 8.
- Usar solo Fak como nombre visible en documentos/resumen.

## Resultado esperado

Crear resumen en:

```text
Codex_Review/025_verificar_paquetes_ui_winforms_resumen.md
```

El resumen debe indicar:

- que paquetes estaban instalados;
- que paquetes se agregaron si faltaba alguno;
- versiones detectadas;
- resultado de restore/build/publish;
- si hay warnings importantes;
- si el repo queda limpio y sincronizado.

## Siguiente paso futuro

Si esta verificacion sale bien, la siguiente tarea sera usar `FontAwesome.Sharp` solo en sidebar y botones principales. No hacerlo en esta tarea.
