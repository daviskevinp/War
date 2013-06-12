library("ggplot2")
library(scales)
warData <- read.csv("c:\\war\\war-withShuffles.csv", header=T)

print(qplot(warData$NumTricks))
ggplot(warData, aes(x=NumTricks)) + geom_histogram(binwidth=25000, colour="black", fill="white")
ggplot(warData, aes(x=NumTricks)) + geom_histogram(binwidth=25000, colour="black", fill="white")+ scale_y_continuous(trans=log10_trans())
