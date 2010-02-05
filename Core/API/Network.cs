using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GithubSharp.Core.Services;

namespace GithubSharp.Core.API
{
    public class Network : Base.BaseAPI, Base.IBaseAPI
    {

		
        //Get Meta
        //http://github.com/erikzaadi/jQueryPlugins/network_meta
        /*
     {
  "focus": 78,
  "nethash": "fa8fe264b926cdebaab36420b6501bd74402a6ff",
  "dates": [
    "2008-03-15",
    "2008-03-15",
    "2008-03-17",
    "2008-03-17",
    ...
    "2009-02-15",
    "2009-02-15",
    "2009-03-19"
  ],
  "users": [
    {
      "name": "schacon",
      "repo": "simplegit",
      "heads": [ { "name": "master",
       "id": "96476742093b8a53947564b16a691349dad846e5" } ]
    },
    {
      "name": "tamtam",
      "repo": "tam_repo",
      "heads": [ { "name": "master",
 	  "id": "8bf4aeae935422e7bdbb30660b4f3642728a1397" } ]
    }
  ],
  "blocks": [
    { "name": "schacon", "start": 0, "count": 3 },
    { "name": "tamtam", "start": 3,  "count": 1 },
  ]
}       */


        //Network Data
        //http://github.com/schacon/simplegit/network_data_chunk?nethash=fa8fe264b926cdebaab36420b6501bd74402a6ff
        //Optional, add range "start" and "end"
        /*
         {
	  "commits": [
	    {
	      "message": "my second commit, which is better than the first",
	      "time": 1,
	      "parents": [
	        [
	          "a11bef06a3f659402fe7563abf99ad00de2209e6",
	          0,
	          1
	        ]
	      ],
	      "date": "2008-03-15 16:40:33",
	      "author": "Scott Chacon",
	      "id": "0576fac355dd17e39fd2671b010e36299f713b4d",
	      "space": 1,
	      "gravatar": "9375a9529679f1b42b567a640d775e7d",
	      "login": "schacon"
	    },
	    {
	      "message": "changed the verison number",
	      "time": 2,
	      "parents": [
	        [
	          "0576fac355dd17e39fd2671b010e36299f713b4d",
	          1,
	          1
	        ]
	      ],
	      "date": "2008-03-17 21:52:11",
	      "author": "Scott Chacon",
	      "id": "0c8a9ec46029a4e92a428cb98c9693f09f69a3ff",
	      "space": 1,
	      "gravatar": "9375a9529679f1b42b567a640d775e7d",
	      "login": "schacon"
	    }
	  ]
	}
         */
    }
}
