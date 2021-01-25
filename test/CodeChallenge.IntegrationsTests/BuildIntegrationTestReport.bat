echo Gerando relatorio de cobertura de testes

rmdir .\BuildReports\IntegrationTests /Q /S
del /Q /F ..\..\src\CodeChallenge.WebApi\wwwroot\App_Data\output-backend.json
del /Q /F ..\..\src\CodeChallenge.WebApi\wwwroot\App_Data\output-backend-csv.json

dotnet.exe test --results-directory ./BuildReports/IntegrationTests ^
            --collect:"XPlat Code Coverage" ^
            /p:CollectCoverage=true ^
            /p:CoverletOutput=./BuildReports/Coverage ^
            /p:CoverletOutputFormat=cobertura ^
            /p:Exclude="[xunit.*]*

@echo off
set back=%cd%
for /d %%i in (.\BuildReports\IntegrationTests\*) do (
cd "%%i"
copy /Y .\*.* ..
)
cd %back%

dotnet %USERPROFILE%\.nuget\packages\reportgenerator\4.8.4\tools\netcoreapp3.0\ReportGenerator.dll "-reports:BuildReports\IntegrationTests\coverage.cobertura.xml" "-targetdir:BuildReports\Coverage" -reporttypes:HTML;HTMLSummary

start .\BuildReports\Coverage\index.html
