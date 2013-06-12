library("ggplot2")
a = c(1,3,1,0,1)
b = sqrt(a)

mydata <- data.frame(muon_momentum = factor(c(.5, 1.5, 2.5, 3.5, 4.5)), count = a)

ggplot(data=mydata, aes(x=muon_momentum, y=count, fill=muon_momentum))+ geom_bar(colour="black", stat="identity")
ggplot(data=mydata, aes(x=muon_momentum, y=count, fill=muon_momentum))+ geom_bar(colour="black", stat="identity")+ geom_errorbar(aes(ymin=count-b, ymax=count+b), width=.1)