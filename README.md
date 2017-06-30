# psgoWurple
Crufty program to generate psgo diagrams for LaTex

Since there are few words which rhyme with purple, this package has been deliberately named to help troubled or needy poets or writers. Now what does this crufty tool actually do, that's the kind of question you might want to ask before reading any further. It is with luck then that we have not onl asked it for you, but are about to answer it for you. Before we do, let's give a quote that has absolutely no merit other than subscribing to the pretentious code meme.

*"The demand that I make of my reader is that he should devote his whole Life to reading my works" - James Joyce*

This package takes as its input a Go diagram and outputs some code for the psgo LaTex package. The input can take 2 forms, that of an Ascii diagram from the preview pane in Senseis Library(SL), or an SGF file. The code is just in its infancy, so various clunks are still present.

### Ascii
SL offers a rather limited facility for diagram creation. If your Go diagramming desires are simplistic in nature, you may find this useful. The markup available on SL is of course limited, so as generated your initial diagram will be limited unless you decide to extend or alter it. The initial version contains the ability to intake only one diagram at a time. I don't expect to upgrade that given the low usage I would expect.

### SGF
Smart Game Format(SGF) is now the standard file format for Go. The workflow we have here is very different to what you might use with a more standard diagramming tool such as GoWrite. We just write pseudocode down in the comments to indicate what should be produced, if anything, from a node. In some ways, I suppose this is almost a nod to the abandoned Ishi file format. Your pseudocode keywords are
* DIAGRAM_START ,
* FULL_BOARD *N* ,
* PART_BOARD *BL TR* , 
* START_MOVE_NBR *N* ,
* PREV_MOVE_NBR *N* ,
* DIAGRAM_END
Disgacefully, we do not document what any of these keywords mean, nor identify the parameters they take. 

Depending on what sgf editor you actually use, the ease of use of this crufty program will vary like a political certainty.
