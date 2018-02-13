all: clean-build

build-test: clean-build test

clean-build : cleanup restore build
 
cleanup:
	dotnet clean PuzzleSolverProject/PuzzleSolverProject.csproj
	dotnet clean PuzzleSolverUnitTest/PuzzleSolverUnitTest.csproj
 
restore:
	dotnet restore PuzzleSolverProject/PuzzleSolverProject.csproj
	dotnet restore PuzzleSolverUnitTest/PuzzleSolverUnitTest.csproj
 
build:
	dotnet build PuzzleSolverProject/PuzzleSolverProject.csproj -o ../Executables
	dotnet build PuzzleSolverUnitTest/PuzzleSolverUnitTest.csproj
	
test:
		dotnet test PuzzleSolverUnitTest/PuzzleSolverUnitTest.csproj