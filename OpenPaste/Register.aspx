<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="OpenPaste.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <link rel="stylesheet" href="Apperance/Default.css" />
</head>
<body>
    <form class="login_user" runat="server" method="post">
        <div class="form_row">
            <div class="name">Username or email</div>
            <div class="input"><asp:textbox runat="server" type="text" name="username" /></div>
        </div>
        <div class="form_row">
            <div class="name">Password</div>
            <div class="input"><asp:textbox runat="server" type="password" name="password" /></div>
        </div>
        <div class="form_summary">
            <asp:Button runat="server" Text="Register" />
        </div>
    </form>
    
    <form class="register_user" method="post">
        <div class="form_row">
            <div class="name">Name</div>
            <div class="input"><input name="register_name" type="text" /></div>
        </div>
        <div class="form_row">
            <div class="name">Surname</div>
            <div class="input"><input name="register_surname" type="text" /></div>
        </div>
        <div class="form_row">
            <div class="name">Mail</div>
            <div class="input"><input name="register_mail" type="text" /></div>
        </div>
        <div class="form_row">
            <div class="name">Password</div>
            <div class="input"><input name="register_password" type="password" /></div>
        </div>
        <div class="form_row">
            <div class="name">Retype password</div>
            <div class="input"><input name="register_retype_password" type="password" /></div>
        </div>
        <div class="form_row">
            <div class="name">Date of birth</div>
            <div class="input"><input name="register_birth_date" type="text" /></div>
        </div>
        <div class="form_row">
            <div class="name">Where the hell you heard about this service?!</div>
            <div class="input">
                <select name="register_information_origin">
                        <option value="web">web</option>
                        <option value="social">social network</option>
                        <option value="friends">friends</option>
                        <option value="hell">hell indeed</option>
                 </select>
            </div>
        </div>
        <div class="form_summary">
            <input type="submit" value="Register me!" />
        </div>
    </form>

    <!-- Marked as formularz dodania kodu -->
    
    <form class="paste_code">
        <div class="form_row">
            <div class="name">
                Language
            </div>
            <div class="input">
                <select name="lang">
                    <option value="asm">ASM</option>
                    <option value="c_plus_plus">C++</option>
                    <option value="c_sharp">C#</option>
                    <option value="makefile">Makefile</option>
                    <option value="java">Java</option>
                    <option value="python">Python</option>
                    <option value="ruby">Ruby</option>
                </select>
            </div>
        </div>
        <div class="form_code_paste">
            <textarea name="code"></textarea>
        </div>
        <div class="form_summary">
            <input type="submit" value="Paste it!" />
        </div>
    </form>

    <div class="pastes">
        <div class="paste">
            <div class="code">
                <span class="java_import">import java.lang</span><br />
                <span class="java_function">public static</span> <span class="java_type">void</span> doItRight() {</br>
                somethingHere();<br />
                }<br />
            </div>
            <div class="details">
                <div class="user">Dawid</div>
                <div class="time">2013-11-03</div>
                <div class="title">Whoa what i broke here?</div>
            </div>
        </div>
        <div class="paste">
            <div class="code">
                <span class="java_import">import java.lang</span><br />
                <span class="java_function">private</span> <span class="java_type">int</span> openMethod() {</br>
                <span class="java_type">int</span> value = 1;<br />
                }<br />
            </div>
            <div class="details">
                <div class="user">Adrian</div>
                <div class="time">2013-11-11</div>
                <div class="title">Why the hell i pasted it in future?!</div>
            </div>
        </div>
    </div>

    <div class="abuse_reports">
        <table>
            <thead>
                <td>Paste#</td>
                <td>Abuse Reason</td>
                <td>Action</td>
            </thead>
            <tr>
                <td>4324</td>
                <td>porn</td>
                <td><button>Remove</button><button>Refuse</button></td>
            </tr>
            <tr>
                <td>433234</td>
                <td>porn</td>
                <td><button>Remove</button><button>Refuse</button></td>
            </tr>
            <tr>
                <td>43243243</td>
                <td>porn</td>
                <td><button>Remove</button><button>Refuse</button></td>
            </tr>
            <tr>
                <td>432423434</td>
                <td>porn</td>
                <td><button>Remove</button><button>Refuse</button></td>
            </tr>
        </table>
    </div>

    <form class="abuse_report">
        <div class="form_row">
            <div class="name">Abused paste</div>
            <div class="value">#417432</div>
        </div>

        <div class="form_row" >
            <div class="name">Reason</div>
            <div class="value">
                <select name="abuse_reason">
                    <option name="porn">porn link</option>
                    <option name="closed">closed code</option>
                    <option name="repeated">repeated paste</option>
                </select>
            </div>
        </div>
        <div class="form_summary">
            <input type="submit" value="Report"/>
        </div>
    </form>
    <div class="users">
        <table>
            <thead>
                <td>Username</td>
                <td>Email</td>
                <td>Amount of pastes</td>
                <td>Actions</td>
            </thead>
            <tr>
                <td>puradawid</td>
                <td>puradawid@gmail.com</td>
                <td>100</td>
                <td><button>Ban</button><button>Edit</button></td>
            </tr>
            <tr>
                <td>rutkowskiadrina</td>
                <td>adrian.rutkowsky@gmail.com</td>
                <td>0</td>
                <td><button>Ban</button><button>Edit</button></td>
            </tr>
        </table>
    </div>
</body>
</html>
