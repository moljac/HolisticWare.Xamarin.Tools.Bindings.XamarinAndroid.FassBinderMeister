#! /usr/bin/env Rscript

wd <- setwd(".")
setwd(wd)
print(wd)
getSrcDirectory(function(x) {x})

initial.options <- commandArgs(trailingOnly = FALSE)
file.arg.name <- "--file="
script.name <- sub(file.arg.name, "", initial.options[grep(file.arg.name, initial.options)])
script.basename <- dirname(script.name)

# Rscript  Tests00Data.R
# R -e 'source("./Tests00Data.R")'
data <- c( 
1, 2, 2, 3, 3, 4, 5, 6 
)
print(data)

other.name <- paste(sep="/", script.basename, "Tests011MeasuresCentralTendencies.R")
print(paste("Sourcing",other.name,"from",script.name))
source(other.name)


# returns the path of the current script file. It works after the script was saved.
# script.dir <- dirname(sys.frame(1)$ofile)

dir()
setwd("./")
dir()

sys.source("Tests011MeasuresDistribution.R")