Set-Location .\SUtilitiesTests\TestResults
Set-Location $(Get-ChildItem)
Copy-Item coverage.cobertura.xml ..\..\..\coverage.xml
Set-Location ..\..\..\