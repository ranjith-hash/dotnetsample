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
                dotnetPublish configuration: 'Release', project: 'DotnetTestDrivenDev', sdk: 'dotnet7', selfContained: false, outputDirectory: 'publish-${BUILD_ID}'
            }
        }
        stage('Deploy to webserver'){
            steps{
                script{

                    def remoteCommand = '''
                        #!/bin/bash
                        echo "Executing remote commands..."
                        rm -rf webapps/site/*
                        unzip webapps/tmp/artifacts-${BUILD_ID}.zip -d webapps/tmp/
                        cp -r webapps/tmp/publish-${BUILD_ID}/* webapps/site
                        echo "Command 2"
                        echo "Command 3"
                        # Add more commands as needed
                    '''

               sh 'zip -r artifacts-${BUILD_ID}.zip publish-${BUILD_ID}'
                sshPublisher(
                    continueOnError: false, failOnError: true,
                    publishers:[
                        sshPublisherDesc(
                        configName: "webserver",
                        verbose: true,
                        transfers: [
                            
                            // sshTransfer(sourceFiles: 'publish-${BUILD_ID}/**/*', remoteDirectory: 'webapps'),
                            sshTransfer(sourceFiles: 'artifacts-${BUILD_ID}.zip', remoteDirectory: 'webapps/tmp'),
                            sshTransfer(execCommand: remoteCommand)
                        ]
                    )
                    ]
                )

                }
                
                // sh 'rm -rf publish-${BUILD_ID}.zip'
                
            }
        }

        stage('archiveArtifacts'){
            steps{
                archiveArtifacts artifacts: "publish-${BUILD_ID}/**/*", followSymlinks: false
            }
        }

    }
}