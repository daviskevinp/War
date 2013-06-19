library("ggplot2")

warData <- read.csv("c:\\temp\\war-withShuffles.csv", header=T)

print(qplot(warData$NumTricks)) 



