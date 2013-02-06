"C:\Program Files (x86)\NUnit 2.6.2\bin\nunit-console.exe" /labels /out=TestResult.txt /xml=TestResult.xml /framework=net-4.0 /fixture:CoolToolSite.Tests.SanityTests.AllTests "C:\buildAuto\CoolToolSite.Tests\bin\Debug\CoolToolSite.Tests.dll"
"C:\tools\src\SpecFlow\packages\SpecFlow.1.7.1\tools\specflow.exe" nunitexecutionreport "C:\buildAuto\CoolToolSite.Tests\CoolToolSite.Tests.csproj"
IF NOT EXIST TestResult.xml GOTO FAIL
IF NOT EXIST TestResult.html GOTO FAIL
EXIT
:FAIL
echo ##teamcity[buildStatus status='FAILURE']
EXIT /B 1