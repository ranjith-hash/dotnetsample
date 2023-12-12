pipeline{

    agent any

    stages{
        stage("Checkout"){
            git branch: 'main', url: "https://github.com/ranjith-hash/dotnetsample.git"
            
        }

        stage("Dotnet Restore"){
            sh "echo restore"
        }

        stage("Dotnet Build"){
            sh "echo build"
        }

        stage("Dotnet publish"){
            sh "echo publish"
        }




    }
}