pipeline {
  trigger{
        cron('0 0 * * 5')
	}
  agent {label 'selenium'}
  stages {
    stage('Cloning Git') {
        steps {
            git credentialsId: 'mvp', url: 'http://git.mvp.studio/talent-group/talent.specflow.git'
      }
    }
	  
    stage('Pull Docker Images') {
		steps {
			bat 'docker-compose pull'
			  }
		}
		
    stage('Starting Docker-compose') {
		steps {
			bat 'docker-compose up -d & sleep 120'
			  }
		}
		
	stage('Run Acceptance test') {
		steps {
			bat 'dotnet test Talent.Automation\\Talent.Automation.csproj'
			  }
	  }
    }   
   post { 
        always { 
            publishHTML([allowMissing: false, alwaysLinkToLastBuild: false, keepAll: false, reportDir: 'Talent.Automation\\ExtendReport', reportFiles: 'index.html', reportName: 'HTML Report', reportTitles: ''])

            echo 'Shut down and clean up containers'
			bat 'docker-compose down'
        }
    }
}