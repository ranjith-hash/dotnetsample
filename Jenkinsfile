pipeline{
    agent any

    stages{
        stage('restore'){
            steps{
                dotnetRestore project: 'DotnetTestDrivenDev', sdk: 'dotnet7'
            }
        }

        stage('Build'){
            steps{
                dotnetBuild configuration: 'Release', project: 'DotnetTestDrivenDev', sdk: 'dotnet7'
            }
        }

        stage('Publish'){
            steps{
                dotnetPublish configuration: 'Release', project: 'DotnetTestDrivenDev', sdk: 'dotnet7', selfContained: false
            }
        }

    }
}