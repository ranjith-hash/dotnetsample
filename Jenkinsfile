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

        stage('Unit Test'){
            steps{
                dotnetTest configuration: 'Release', project: 'DotnetTestDrivenDev.Test', sdk: 'dotnet7'
            }
        }

        stage('Publish'){
            steps{
                dotnetPublish configuration: 'Release', project: 'DotnetTestDrivenDev', sdk: 'dotnet7', selfContained: false, outputDirectory: 'version/publish-${BUILD_ID}'
            }
        }
        stage('Deploy to webserver'){
            steps{
                script{
                    sshPublisher configName:'webserver' sourceFiles:'version/publish-${BUILD_ID}'  remoteDirectory:'webapps'

                }
            }
        }

        stage('archiveArtifacts'){
            steps{
                archiveArtifacts artifacts: "version/publish-${BUILD_ID}/**/*", followSymlinks: false
            }
        }

    }
}