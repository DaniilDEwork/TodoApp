param(
    [ValidateSet('Wpf', 'WinForms', 'Both')]
    [string]$Mode = 'Both'
)

$ErrorActionPreference = 'Stop'

try {
    $taskExecutables = @()

    if ($Mode -eq 'Wpf' -or $Mode -eq 'Both') {
        $taskExecutables += Join-Path $PSScriptRoot 'TodoApp.Wpf\bin\Debug\TodoApp.Wpf.exe'
    }

    if ($Mode -eq 'WinForms' -or $Mode -eq 'Both') {
        $taskExecutables += Join-Path $PSScriptRoot 'TodoApp.WinForms\bin\Debug\TodoApp.WinForms.exe'
    }

    $taskNeedsBuild = $false

    foreach ($taskExecutable in $taskExecutables) {
        $taskCoreLibrary = Join-Path (Split-Path -Parent $taskExecutable) 'TodoApp.Core.dll'

        if (-not (Test-Path -LiteralPath $taskExecutable) -or -not (Test-Path -LiteralPath $taskCoreLibrary)) {
            $taskNeedsBuild = $true
        }
    }

    if ($taskNeedsBuild) {
        $taskMsbuildCommand = Get-Command 'MSBuild.exe' -ErrorAction SilentlyContinue
        $taskMsbuildPath = $null

        if ($taskMsbuildCommand) {
            $taskMsbuildPath = $taskMsbuildCommand.Source
        }
        else {
            $taskVswherePath = Join-Path ${env:ProgramFiles(x86)} 'Microsoft Visual Studio\Installer\vswhere.exe'

            if (Test-Path -LiteralPath $taskVswherePath) {
                $taskMsbuildPath = & $taskVswherePath -latest -products '*' -requires Microsoft.Component.MSBuild -find 'MSBuild\Current\Bin\MSBuild.exe' | Select-Object -First 1
            }
        }

        if (-not $taskMsbuildPath) {
            throw 'Для сборки нужна Visual Studio с поддержкой WPF и Windows Forms на .NET Framework 4.8'
        }

        Write-Host 'Сборка приложения'
        & $taskMsbuildPath (Join-Path $PSScriptRoot 'TodoApp.sln') /t:Build /p:Configuration=Debug /m /nologo /verbosity:minimal

        if ($LASTEXITCODE -ne 0) {
            throw 'Не удалось собрать решение'
        }
    }

    foreach ($taskExecutable in $taskExecutables) {
        Start-Process -FilePath $taskExecutable -WorkingDirectory (Split-Path -Parent $taskExecutable) -WindowStyle Normal
    }
}
catch {
    Write-Host $_.Exception.Message -ForegroundColor Red
    Read-Host 'Нажмите Enter, чтобы закрыть окно'
    exit 1
}
