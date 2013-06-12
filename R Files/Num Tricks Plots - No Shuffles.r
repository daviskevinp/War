library("ggplot2")
library(scales)
warData <- read.csv("c:\\war\\war-noShuffle.csv", header=T)

qplot( warData$NumTricks)
qplot( warData[warData$NumTricks < 100000,]$NumTricks )
nrow(warData[warData$NumTricks > 100000,])
nrow(warData)
mean(warData[warData$NumTricks < 100000,]$NumTricks)
nrow(warData[warData$NumTricks > 100000,])/nrow(warData)* 100