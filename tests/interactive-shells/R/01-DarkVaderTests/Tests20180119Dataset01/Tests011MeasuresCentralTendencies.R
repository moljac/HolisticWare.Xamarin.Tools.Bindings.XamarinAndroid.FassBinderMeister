#! /usr/bin/env Rscript

install.packages("here", repos = "http://cran.us.r-project.org")
library(here)

if (! exists("data", inherits = FALSE))
{
    #initial.options <- commandArgs(trailingOnly = FALSE)
    #file.arg.name <- "--file="
    script.name <- sub(file.arg.name, "", initial.options[grep(file.arg.name, initial.options)])
    script.basename <- dirname(script.name)

    other.name <- paste(sep="/", script.basename, "Tests00Data.R ")
    print(paste("Sourcing",other.name,"from",script.name))
    #source(other.name)

    source(here::here('Tests00Data.R'))
}

 print(data)



# use the R function '.libPaths()' to both query and change the current location R will use to install 
# new user-contributed libraries.

# For example:

# .libPaths("/home/moljac/Rlib")

 

# To change the default location in which to add R user contributed libraries permanently, you can add 
# this to your user-specific  .'Rprofile' file or to the system-wide '.Rprofile.site'  in 
# '/usr/lib64/Revo-7.3/R-3.1.1/lib64/R/etc', if you need to change this setting for all of your R users.