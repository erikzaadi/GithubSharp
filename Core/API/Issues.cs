using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GithubSharp.Core.API
{
    public class Issues
    {
        //Search issues
        //issues/search/:user/:repo/:state/:search_term 
        //Where state can be closed, open

        //List a Projects Issues
        //http://github.com/api/v2/yaml/issues/list/schacon/simplegit/:state
        //Where state can be closed, open


        //View an Issue
        //http://github.com/api/v2/yaml/issues/show/schacon/simplegit/:number

        //Authenticate
        //Open issue (POST)
        //http://github.com/api/v2/yaml/issues/open/:user/:repo

        //Authenticate
        //ReOpen issue (POST)
        //http://github.com/api/v2/yaml/issues/reopen/:user/:repo/:number

        //Authenticate
        //Close issue (POST)
        //http://github.com/api/v2/yaml/issues/close/:user/:repo/:number
        //values : title, body

        //Authenticate
        //Edit issue (POST)
        //http://github.com/api/v2/yaml/issues/edit/:user/:repo/:number
        //values : title, body

        //Listing Labels
        //http://github.com/api/v2/yaml/issues/labels/schacon/simplegit

        //Authenticate
        //Add label (creates on if it doesn't exist)
        //http://github.com/api/v2/yaml/issues/label/add/:user/:repo/:label/:issuenumber

        //Authenticate
        //Remove label 
        //http://github.com/api/v2/yaml/issues/label/remove/:user/:repo/:label/:issuenumber

        //Authenticate
        //Comment on issue (POST)
        // http://github.com/api/v2/json/issues/comment/:user/:repo/:issuenumber
        //values = comment
    }
}
