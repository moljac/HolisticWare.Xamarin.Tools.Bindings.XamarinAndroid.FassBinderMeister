#!/bin/bash


export PREFIX=.
# export PREFIX=./samples/console/apps/project-references/

export PROJECTS=\
"
$PREFIX/HolisticWare.Xamarin.Tools.NeekNoke.Newtonsoft.JSON/
$PREFIX/HolisticWare.Xamarin.Tools.NeekNoke.System.Text.JSON/
$PREFIX/HolisticWare.Xamarin.Tools.NeekNoke.Jil/
$PREFIX/HolisticWare.Xamarin.Tools.NeekNoke.SpanJson/
"

IFS=$'\n'
# ZSH does not split words by default (like other shells):
setopt sh_word_split

for PROJECT in $PROJECTS;
do
    echo $PROJECT

    for i in {1..10}
    do
        dotnet run \
            --configuration Release \
            --property:Configuration=Release \
            --project $PROJECT \
            -- neek
    done

done




#        dotnet run \
#            --configuration Release \
#            --property:Configuration=Release \
#            --project ./samples/console/apps/project-references/HolisticWare.Xamarin.Tools.NeekNoke.SpanJson \
#            -- neek
