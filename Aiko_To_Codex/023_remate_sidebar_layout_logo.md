# 023 - Remate sidebar, layout e icono de app

Estado: lista para Codex
Fecha: 2026-06-14

## Contexto

La issue #11 / tarea 022 ya hizo que la sidebar cambie entre secciones reales. Esta tarea NO repite esa navegacion.

Ahora hay que corregir problemas visuales y funcionales detectados despues de probar la version publicada.

## Objetivo

Rematar la sidebar y el layout de las paginas para que la app no parezca rota ni corte botones.

## Correcciones obligatorias

### Sidebar

- Quitar la barra horizontal blanca de la sidebar.
- Evitar scroll horizontal en la sidebar.
- Mantener scroll vertical solo si es necesario.
- El scroll no debe verse como una caja blanca fea si se puede evitar.
- La tarjeta `Proyecto actual` debe quedar abajo del todo de la sidebar.
- La tarjeta `Proyecto actual` no debe moverse junto con el scroll de botones, salvo que no haya otra opcion tecnica.
- Aprovechar el espacio vertical inferior de la sidebar.
- Evitar que parezca que hay opciones ocultas sin forma clara de acceder.

### Layout de paginas

Al cambiar de seccion desde la sidebar:

- Ninguna pagina debe tener botones tapados.
- Ninguna pagina debe dejar contenido importante fuera sin scroll.
- Cada pagina debe tener titulo claro y una accion principal clara.
- Si hay demasiados botones, usar grid compacto o panel con scroll.
- Evitar paneles enormes vacios.

### Icono/logo de app

Añadir logo de AikoGx como icono de la app y del exe si es posible.

Ruta local indicada por Fak:

```text
H:\AikoGxCloud\AikoGxcloud\Logo AikoGx\LOGO DIF.png
```

Si Codex no puede acceder a esa ruta local:

- dejar preparado soporte para `Assets/Logo/LOGO DIF.png`;
- indicar en el resumen que Fak debe copiar el archivo a esa carpeta;
- convertir a `.ico` si es necesario para `ApplicationIcon`;
- configurar el `.csproj` para usar el icono cuando exista.

## Reglas

- Mantener WinForms .NET 8.
- No rehacer la app desde cero.
- No romper navegacion de la tarea 022.
- No publicar automaticamente.
- WordPress siempre draft.
- Usar solo Fak como nombre visible.

## Validacion

Probar:

- abrir app maximizada;
- sidebar sin scroll horizontal;
- tarjeta Proyecto actual abajo;
- clic en Inicio;
- clic en Notas del Dia;
- clic en Ideas / Content Bank;
- clic en Tareas;
- clic en Archivos y Material;
- clic en Estado del Proyecto;
- clic en Ajustes;
- comprobar que no hay botones tapados;
- comprobar que el icono se aplica o queda instruccion clara para copiar logo.

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
Codex_Review/023_remate_sidebar_layout_logo_resumen.md
```
