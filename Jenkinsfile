pipeline{
    agent any

    stages{
        stage('Checkout'){
            steps{
                git branch: 'main', url: 'https://github.com/ranjith-hash/dotnetsample.git'
            }
        }

        stage('Restore'){
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
                dotnetPublish configuration: 'Release', project: 'DotnetTestDrivenDev', sdk: 'dotnet7', selfContained: false, outputDirectory: 'version/publis-${BUILD_ID}.zip'
            }
        }

    }
}