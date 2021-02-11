import React from 'react'
import homeStyles from './Home.Styles'

class Home extends React.Component {
    render(){
        return(<div style={homeStyles.body}> 
                    <div style={homeStyles.header}> 
                        <div style={homeStyles.right}></div>
                        <div style={homeStyles.center}></div>
                        <div style={homeStyles.left}></div>
                    </div>
                    <div style={homeStyles.main}>
                        <div style={homeStyles.form}></div>
                    </div>
                    <div style={homeStyles.footer}> Footer </div>
               </div>)
    }
}

export default Home