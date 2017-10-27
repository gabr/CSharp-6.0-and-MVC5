$vstest = "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe"

.\build.ps1 ANOUC.Tests

& $vstest .\ANOUC.Tests\bin\Debug\ANOUC.Tests.dll

