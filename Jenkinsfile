pipeline{

    agent any

    stages{
        stage("Checkout"){
            git branch: 'main', url: "https://github.com/ranjith-hash/dotnetsample.git"
            
        }

        stage("Dotnet Restore"){
            sh 'echo "sample"'
        }

        stage("Dotnet Build"){
            sh 'echo "sample"'
        }

        stage("Dotnet publish"){
            sh 'echo "sample"'
        }




    }
}