pipeline{

    agent any

    stages{
        stage("Checkout"){
            steps{
                git branch: 'main', url: "https://github.com/ranjith-hash/dotnetsample.git"
                
            }
            
            
        }

        stage("Dotnet Restore"){
            steps{
                scripts{
                    sh 'echo "sample"'
                    
                }
            }
        }

        stage("Dotnet Build"){
            steps{
                scripts{
                    sh 'echo "sample"'

                }
            }
        }

        stage("Dotnet publish"){
            steps{
                scripts{
                    sh 'echo "sample"'
                    
                }
            }
        }




    }
}