REM Gerando relatorio de cobertura de testes

dotnet.exe test --results-directory ./BuildReports/UnitTests ^
            --collect:"CodeChallenge Code Coverage" ^
            /p:CollectCoverage=true ^
            /p:CoverletOutput=BuildReports\Coverage ^
            /p:CoverletOutputFormat=cobertura ^
            /p:Exclude="[xunit.*]*

REM dotnet %USERPROFILE%\.nuget\packages\reportgenerator\4.8.4\tools\netcoreapp3.0\ReportGenerator.dll "-reports:BuildReports\UnitTests\5efe8ed9-5570-450e-8bbe-bfcd3f480a61\coverage.cobertura.xml" "-targetdir:BuildReports\Coverage" -reporttypes:HTML;HTMLSummary
