all: clean-build

build-test: clean-build test

clean-build : cleanup restore build
 
cleanup:
	dotnet clean WordSearchKata.sln
 
restore:
	nuget restore WordSearchKata.sln
 
build:
	dotnet build PuzzleSolverProject/PuzzleSolverProject.csproj -o ../Executables
	dotnet build PuzzleSolverUnitTest/PuzzleSolverUnitTest.csproj
	
test:
		dotnet test PuzzleSolverUnitTest/PuzzleSolverUnitTest.csproj