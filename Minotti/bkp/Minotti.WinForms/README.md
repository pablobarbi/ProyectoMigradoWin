
Minotti.WinForms (.NET 8 / WinForms)

Requisitos:
- Visual Studio 2022 (v17.x)
- .NET 8 SDK
- Driver ODBC de SQL Anywhere 9 (idealmente de 32 bits si mantenés PlatformTarget x86)

Conexión a SQL Anywhere 9 por DSN:
- Creá un DSN del sistema llamado, por ejemplo, "MinottiDSN" apuntando a tu base.
- En los forms que exponen la propiedad pública `Dsn` (p.ej. `w_reperto_anterior_multiple_lista`),
  setealo antes de abrirlos: `form.Dsn = "MinottiDSN";`

Estructura:
- Namespace: Minotti
- Carpeta Views: contiene los Windows migrados 1:1 que ya generamos: —

Inicio de la aplicación:
- Por defecto inicia `w_ver_medicamentos` (mirá `Program.cs`). Podés cambiar la línea:
    Application.Run(new w_ver_medicamentos());
  por otra window que prefieras.

Notas de compatibilidad:
- El proyecto compila para `net8.0-windows` y está apuntado a x86 (32 bits) por compatibilidad con SA9.
  Si tenés driver ODBC de 64 bits y DSN de 64 bits, podés editar el .csproj y quitar:
    <PlatformTarget>x86</PlatformTarget>
    <Prefer32Bit>true</Prefer32Bit>

Agregando más ventanas:
- Si necesitás agregar más SRW/SRD/SRF migrados, copiá los `.cs` y `.Designer.cs` a `Views/`. Manteneremos nombres y lógica literal.


---
### DSN de 32‑bits en Windows 64‑bits
- Abrí el **Administrador ODBC de 32‑bits**: `C:\Windows\SysWOW64\odbcad32.exe`.
- Creá un **DSN de Sistema** llamado **MinottiDSN** con el driver **SQL Anywhere 9** (32‑bits).
- Probá con el botón **Test Connection** del ODBC y luego ejecutá la app.
