pipeline {
    agent any

    environment {
        DOTNET_SDK_VERSION = 'dotnet7' // Set the .NET SDK version
    }

    stages {
        stage('Checkout') {
            steps {
                git branch : 'main', url: 'https://github.com/ranjith-hash/dotnetsample.git'
            }
        }

        stage('Dotnet Restore'){
            steps{
                dotnetRestore project: 'DotnetTestDrivenDev', sdk: ${DOTNET_SDK_VERSION}
            }
        }

        stage('Build') {
            steps {
                script {
                    // Install and use the specified .NET SDK version
                    

                    // Build the .NET application
                    dotnetBuild configuration: 'Release', project: 'DotnetTestDrivenDev', sdk: ${DOTNET_SDK_VERSION}
                }
            }
        }

        stage('Test') {
            steps {
                script {
                    // Run tests for the .NET application
                   dotnetTest configuration: 'Release', project: 'DotnetTestDrivenDev.Test', resultsDirectory: 'results', sdk: ${DOTNET_SDK_VERSION}
                }
            }
        }

        stage('Publish') {
            steps {
                script {
                    // Publish the .NET application
                    // sh "dotnet publish DotnetTestDrivenDev/ -c Release -o ./publish"
                    dotnetPublish configuration: 'Release', project: 'DotnetTestDrivenDev', sdk: ${DOTNET_SDK_VERSION}, selfContained: false
                }
            }
        }

        stage('Archive Artifacts') {
            steps {
                archiveArtifacts artifacts: 'publish/**/*'
            }
        }
    }

    post {
        success {
            // Additional steps to perform when the pipeline is successful
            echo 'Build, test, and publish successful!'
        }

        failure {
            // Additional steps to perform when the pipeline fails
            echo 'Build, test, or publish failed!'
        }
    }
}
