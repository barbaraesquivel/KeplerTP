# Kepler-7: Protocolo Crisis

Trabajo Práctico Final de la cátedra — *"Kepler-7: El universo de los patrones"*.

Juego de rol táctico por turnos hecho en **C# con Windows Forms (.NET 8)**. La estación orbital Kepler-7 sufre una crisis provocada por la IA hostil **K-7**, y el jugador recorre distintos sectores de la estación para prepararse antes del combate final.

**Equipo:** Barbara, Martin, Lautaro y Axel.

## Requisitos del sistema

- Windows 10/11 (64 bits).
- [.NET 8 Desktop Runtime (x64)](https://dotnet.microsoft.com/download/dotnet/8.0) para correr el ejecutable sin Visual Studio.
- Para compilar: Visual Studio 2022 (carga de trabajo *.NET desktop development*) o el SDK de .NET 8.

## Instalación y ejecución

Hay dos formas de instalarlo:

### Opción A — Instalador (recomendada)

Descargá **[Instalador_Kepler7_1.0.0.exe](https://github.com/barbaraesquivel/KeplerTP/releases/download/v1.0.0/Instalador_Kepler7_1.0.0.exe)** desde los [Releases](https://github.com/barbaraesquivel/KeplerTP/releases) (v1.0.0), ejecutalo y seguí los pasos del instalador. Solo necesitás tener instalado el .NET 8 Desktop Runtime (ver Requisitos).

### Opción B — Clonar y compilar

```bash
git clone https://github.com/barbaraesquivel/KeplerTP.git
cd KeplerTP
dotnet run --project Kepler7.Game -c Release
```

O abrí `KeplerTP.sln` en Visual Studio, marcá **Kepler7.Game** como proyecto de inicio y ejecutá con `F5`.

## Estructura de la solución

```
Kepler7.Core/     → lógica del juego y los 12 patrones de diseño (sin dependencias de Forms)
Kepler7.Game/     → interfaz gráfica (Windows Forms) y navegación de pantallas
```

## Patrones de diseño implementados

**Creacionales:** Builder (Hangar), Prototype (Laboratorio).
**Estructurales:** Bridge (Comunicaciones), Facade (Control Central), Flyweight (Censo), Proxy (Bóveda).
**Comportamiento:** Chain of Responsibility, Command y State (Combate), Template Method (Turnos), Strategy (Estrategia IA), Visitor (Inventario).

El panel de **Logros** dentro del juego va marcando en tiempo real qué patrones se usaron durante la partida.

## Persistencia

El progreso (XP, nivel, monedas y logros) se guarda en `%AppData%\Kepler7\` usando `System.Text.Json`, fuera de la carpeta del ejecutable.

---

## ¿Jugamos?

Instalalo con el `.exe` o cloná y compilá, y metete en la estación. Esto es Kepler-7 en pleno combate:

<img width="801" height="576" alt="combate" src="https://github.com/user-attachments/assets/ce2f91fa-6ef9-4582-8f0a-35a70becbf9d" />
