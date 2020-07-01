node {
    def hangoutsToken = 'G0dA2D0cEFhg_4CoIZmUDt4yY'
    def verbose = false
    def feedbackGitLab = false

    stage('checkout') {
        git branch: 'dev', url: '/d/Projects/git/gitscr1.moneydj.com/XSGroup/more-effective-csharp'
    }
    if (feedbackGitLab) {
        updateGitlabCommitStatus name: "${server}", state: 'pending'
    }
    if (verbose) {
        hangoutsNotify message: 'nuget restoration ...', token: hangoutsToken, threadByJob: true
    }
    def commitMsg = bat returnStdout: true, script: "@echo off&&\"${tool 'git'}\" log -1\""
    stage('nuget restoration') {
        bat returnStdout: true, script: 'dotnet restore more-effective-csharp-2nd-edition\\sources\\more-effective-csharp-2nd-edition.sln'
    }
    if (verbose) {
        hangoutsNotify message: 'build ...', token: hangoutsToken, threadByJob: true
    }
    try {
        stage('build') {
            bat returnStdout: true, script: 'dotnet msbuild -property:Configuration=Debug more-effective-csharp-2nd-edition\\sources\\more-effective-csharp-2nd-edition.sln'
        }
        stage('test') {
            bat label: '', returnStdout: true, script: "\"${tool 'vstest.2019'}\" more-effective-csharp-2nd-edition\\sources\\more-effective-csharp-2nd-edition\\bin\\Debug\\netcoreapp3.1\\more-effective-csharp-2nd-edition.dll /Enablecodecoverage /Platform:x64 /Logger:trx;LogFileName=${BUILD_TAG}.trx /Parallel"
        }
        if (feedbackGitLab) {
            updateGitlabCommitStatus name: "${server}", state: 'success'
        }
        if (verbose) {
            hangoutsNotify message: 'pipeline successed.', token: hangoutsToken, threadByJob: true
        }
    } catch (err) {
        if (feedbackGitLab) {
            updateGitlabCommitStatus name: "${server}", state: 'failed'
        }
        hangoutsNotify message: "${commitMsg}\npipeline failed.\n${err}", token: hangoutsToken, threadByJob: true
        throw err
    }
    finally {
        mstest testResultsFile: "TestResults/${BUILD_TAG}.trx"
    }
}
