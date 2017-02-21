<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ErrorPage.ascx.cs" Inherits="CodeWarfares.Web.CustomControls.ErrorPage" %>
<style>
    /* reset */
    .wrap ol, .wrap ul {
        list-style: none;
        margin: 0px;
        padding: 0px;
    }

    .wrap blockquote, .wrap q {
        quotes: none;
    }

        .wrap blockquote:before, .wrap blockquote:after, .wrap q:before, .wrap q:after {
            content: '';
            content: none;
        }

    .wrap table {
        border-collapse: collapse;
        border-spacing: 0;
    }
    /* start editing from here */
    .wrap a {
        text-decoration: none;
    }

    .wrap .txt-rt {
        text-align: right;
    }
    /* text align right */
    .wrap .txt-lt {
        text-align: left;
    }
    /* text align left */
    .wrap .txt-center {
        text-align: center;
    }
    /* text align center */
    .wrap .float-rt {
        float: right;
    }
    /* float right */
    .wrap .float-lt {
        float: left;
    }
    /* float left */
    .wrap .clear {
        clear: both;
    }
    /* clear float */
    .wrap .pos-relative {
        position: relative;
    }
    /* Position Relative */
    .wrap .pos-absolute {
        position: absolute;
    }
    /* Position Absolute */
    .wrap .vertical-base {
        vertical-align: baseline;
    }
    /* vertical align baseline */
    .wrap .vertical-top {
        vertical-align: top;
    }
    /* vertical align top */
    .wrap .underline {
        padding-bottom: 5px;
        border-bottom: 1px solid #eee;
        margin: 0 0 20px 0;
    }
    /* Add 5px bottom padding and a underline */
    .wrap nav.vertical ul li {
        display: block;
    }
    /* vertical menu */
    .wrap nav.horizontal ul li {
        display: inline-block;
    }
    /* horizontal menu */
    .wrap img {
        max-width: 100%;
    }
    /*end reset*
 */
    .wrap body {
        background: url(/Images/bg1.png);
        font-family: "Century Gothic",Arial, Helvetica, sans-serif;
    }

    .wrap .content p {
        margin: 18px 0px 45px 0px;
    }

    .wrap .content p {
        font-family: "Century Gothic";
        font-size: 2em;
        color: #666;
        text-align: center;
    }

        .wrap .content p span, .wrap .logo h1 a {
            color: #e54040;
        }

    .content {
        text-align: center;
        padding: 115px 0px 0px 0px;
    }

        .content a {
            color: #fff;
            font-family: "Century Gothic";
            background: #666666; /* Old browsers */
            background: -moz-linear-gradient(top, #666666 0%, #666666 100%); /* FF3.6+ */
            background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,#666666), color-stop(100%,#666666)); /* Chrome,Safari4+ */
            background: -webkit-linear-gradient(top, #666666 0%,#666666 100%); /* Chrome10+,Safari5.1+ */
            background: -o-linear-gradient(top, #666666 0%,#666666 100%); /* Opera 11.10+ */
            background: -ms-linear-gradient(top, #666666 0%,#666666 100%); /* IE10+ */
            background: linear-gradient(to bottom, #666666 0%,#666666 100%); /* W3C */
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#666666', endColorstr='#666666',GradientType=0 ); /* IE6-9 */
            padding: 15px 20px;
            border-radius: 1em;
        }

            .content a:hover {
                color: #e54040;
            }

    .logo {
        text-align: center;
        -webkit-box-shadow: 0 8px 6px -6px rgb(97, 97, 97);
        -moz-box-shadow: 0 8px 6px -6px rgb(97, 97, 97);
        box-shadow: 0 8px 6px -6px rgb(97, 97, 97);
    }

        .logo h1 {
            font-size: 2em;
            font-family: "Century Gothic";
            background: #666666; /* Old browsers */
            background: -moz-linear-gradient(top, #666666 0%, #666666 100%); /* FF3.6+ */
            background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,#666666), color-stop(100%,#666666)); /* Chrome,Safari4+ */
            background: -webkit-linear-gradient(top, #666666 0%,#666666 100%); /* Chrome10+,Safari5.1+ */
            background: -o-linear-gradient(top, #666666 0%,#666666 100%); /* Opera 11.10+ */
            background: -ms-linear-gradient(top, #666666 0%,#666666 100%); /* IE10+ */
            background: linear-gradient(to bottom, #666666 0%,#666666 100%); /* W3C */
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#666666', endColorstr='#666666',GradientType=0 ); /* IE6-9 */
            padding: 10px 10px 18px 10px;
        }

            .logo h1 a {
                font-size: 1em;
            }

    .copy-right {
        padding-top: 20px;
    }

        .copy-right p {
            font-size: 0.9em;
        }

            .copy-right p a {
                background: none;
                color: #e54040;
                padding: 0px 0px 5px 0px;
                font-size: 0.9em;
            }

                .copy-right p a:hover {
                    color: #666;
                }
    /*------responive-design--------*/
    @media screen and (max-width: 1366px) {
        .content {
            padding: 58px 0px 0px 0px;
        }
    }

    @media screen and (max-width:1280px) {
        .content {
            padding: 58px 0px 0px 0px;
        }
    }

    @media screen and (max-width:1024px) {
        .content {
            padding: 58px 0px 0px 0px;
        }

            .content p {
                font-size: 1.5em;
            }

        .copy-right p {
            font-size: 0.9em;
        }
    }

    @media screen and (max-width:640px) {
        .content {
            padding: 58px 0px 0px 0px;
        }

            .content p {
                font-size: 1.3em;
            }

        .copy-right p {
            font-size: 0.9em;
        }
    }

    @media screen and (max-width:460px) {
        .content {
            padding: 20px 0px 0px 0px;
            margin: 0px 12px;
        }

            .content p {
                font-size: 0.9em;
            }

        .copy-right p {
            font-size: 0.8em;
        }
    }

    @media screen and (max-width:320px) {
        .content {
            padding: 30px 0px 0px 0px;
            margin: 0px 12px;
        }

            .content a {
                padding: 10px 15px;
                font-size: 0.8em;
            }

            .content p {
                margin: 18px 0px 22px 0px;
            }
    }
</style>

<div class="wrap">
    <!--start-content------>
    <div class="content">
        <h1><asp:Label runat="server" ID="ErrorCodeValue"></asp:Label></h1>
        <p>
            <span>
                <label>О</label>хх..... </span>Страницата, която търсите не съществува.
        </p>
    </div>
    <!--End-Cotent------>
</div>
