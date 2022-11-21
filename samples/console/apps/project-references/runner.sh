#!/bin/bash


#export PREFIX=.
export PREFIX=./samples/console/apps/project-references/

export JSON_LIBRARIES=\
"
Newtonsoft.JSON
System.Text.JSON
Jil
SpanJson
"

IFS=$'\n'
# ZSH does not split words by default (like other shells):
setopt sh_word_split

for JSON_LIBRARY in $JSON_LIBRARIES;
do
    echo $PROJECT

    for i in {1..10}
    do
        dotnet run \
            --configuration Release \
            --property:Configuration=Release \
            --project $PREFIX//HolisticWare.Xamarin.Tools.NeekNoke.$JSON_LIBRARY/ \
            -- \
            neek \
            --file-timing:$PREFIX/timings-$JSON_LIBRARY.csv
    done

done



# export PREFIX=./samples/console/apps/project-references/
# 
#         dotnet run \
#             --configuration Release \
#             --property:Configuration=Release \
#             --project $PREFIX/HolisticWare.Xamarin.Tools.NeekNoke.Newtonsoft.JSON/ \
#             -- \
#             neek \
#             --file-timing:$PREFIX/timings-Newtonsoft.JSON.csv
# 
#         dotnet run \
#             --configuration Release \
#             --property:Configuration=Release \
#             --project $PREFIX/HolisticWare.Xamarin.Tools.NeekNoke.System.Text.JSON/ \
#             -- \
#             neek \
#             --file-timing:$PREFIX/timings-System.Text.JSON.csv
# 
# 
#         dotnet run \
#             --configuration Release \
#             --property:Configuration=Release \
#             --project ./samples/console/apps/project-references/HolisticWare.Xamarin.Tools.NeekNoke.SpanJson \
#             -- \
#             neek \
#             --file-timing:$PREFIX/timings-SpanJson.csv
# 


         dotnet run \
             --configuration Release \
             --property:Configuration=Release \
             --project $PREFIX/BindingConfigurator
